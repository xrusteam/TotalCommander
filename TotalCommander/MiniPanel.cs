using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace TotalCommander
{
    class MiniPanel : Panel
    {
        private Panel PanelForDirectory = new Panel();
        private Panel PanelForButtons = new Panel();
        private TextBox PathTextbox = new TextBox();
        private Button UpButton = new Button();
        private Button DownButton = new Button();
        private Button BackButton = new Button();
        private Button DeleteButton = new Button();
        private Button CreateDirectoryButton = new Button();
        public Action DeleteAction;

        public static Color StartColor = Color.FromArgb(242, 242, 242);
        public static Font StartFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        public MiniPanel()
        {
            Inicalization();
        }
        public MiniPanel(string path)
        {
            Inicalization();
            if (!path.Equals("") && !path.Equals(null))
            {
                ShowIndirectory(new CardFile(path));
            }
        }
        public string GetOpenedDirectory()
        {
            return PathTextbox.Text;
        }
        public List<string> GetSelectedDirectory()
        {
            List<string> paths = new List<String>();
            foreach (CardFile file in AllFiles)
            {
                if (file.IsClicked)
                {
                    paths.Add(file.Path);
                }
            }
            return paths;
        }
        public string[] SelectedFilesPaths { get; set; }

        List<string> PathForDelete = new List<string>();

        List<CardFile> AllFiles = new List<CardFile>();
        List<CardFile> ShowingFiles = new List<CardFile>();
        private int FirstActiveFileCard = 0;
        private int CountofShowingFileCard;

        private int hieghtFileCards = 30;
        private int LengthBetweenFileCards = 5;

        private void SmallPanel_Resize(object sender, EventArgs e)
        {
            ClearFiles();
            CountofShowingFileCard = (PanelForDirectory.Height - 45) / (CardFile.StartFont.Height + 10 + LengthBetweenFileCards); ;
            ShowFiles();

        }
        public void ReColor_Form(Color col)
        {
            PanelForButtons.BackColor = col;
            PanelForDirectory.BackColor = col;
        }
        public void Reload_this_Panel()
        {
            PathTextbox.Font = StartFont;
            if (PathTextbox.Text.Equals(""))
            {
                ClearFiles();
                AllFiles.Clear();
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    AllFiles.Add(new CardFile(drive.Name));
                }
                ShowFiles();
            }
            else
            {
                ShowIndirectory(new CardFile(PathTextbox.Text));
            }

        }

        private void DeleteReload()
        {
            DeleteAction.Invoke();
        }
        private void directory_DoubleClick(object sender, EventArgs e)
        {
            if (sender is CardFile)
            {
                ShowIndirectory(sender as CardFile);
            }
            else if (sender is PictureBox)
            {
                PictureBox pic = sender as PictureBox;
                ShowIndirectory((CardFile)pic.Tag);
            }
            else if (sender is Label)
            {
                Label text = sender as Label;
                ShowIndirectory((CardFile)text.Tag);

            }

        }

        private void ShowIndirectory(CardFile cardp)
        {
            ClearFiles();
            if (Directory.Exists(cardp.Path))
            {
                PathTextbox.Text = cardp.Path;
                AllFiles.Clear();
                cardp.GetDirectories();
                if (!(cardp.GetDirectories() == null))
                {
                    foreach (string path in cardp.GetDirectories())
                    {
                        AllFiles.Add(new CardFile(path));
                    }
                }
                if (!(cardp.GetFiles() == null))
                {
                    foreach (FileInfo file in cardp.GetFiles())
                    {
                        AllFiles.Add(new CardFile(file.FullName));
                    }
                }

            }
            else if (File.Exists(cardp.Path))
            {
                try
                {
                    System.Diagnostics.Process.Start(cardp.Path);

                }
                catch
                {
                    MessageBox.Show("Простите, нельзя открыть этот файл");
                }

            }
            ShowFiles();
        }

        private void TotalCommanderForm_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {

                CardFile File = new CardFile(drive.Name);
                File.Location = new Point(5, LengthBetweenFileCards + i * (hieghtFileCards + LengthBetweenFileCards));
                File.DoubleClick += directory_DoubleClick;
                File.PictureFile.DoubleClick += directory_DoubleClick;
                File.NameFile.DoubleClick += directory_DoubleClick;

                File.Click += Selecte_Click;
                File.PictureFile.Click += Selecte_Click;
                File.NameFile.Click += Selecte_Click;
                ShowingFiles.Add(File);
            }
        }

        private void ClearFiles()
        {
            foreach (CardFile File in ShowingFiles)
            {
                PanelForDirectory.Controls.Remove(File);
            }
            ShowingFiles.Clear();
        }
        private void ShowFiles()
        {
            CountofShowingFileCard = (PanelForDirectory.Height - 50) / (CardFile.StartFont.Height + 10 + LengthBetweenFileCards);
            for (int i = FirstActiveFileCard, j = 0; i < FirstActiveFileCard + CountofShowingFileCard && i < AllFiles.Count; i++, j++)
            {
                hieghtFileCards = CardFile.StartFont.Height + 10;

                AllFiles[i].Size = new Size(Width - 25, hieghtFileCards);
                AllFiles[i].Location = new Point(5, LengthBetweenFileCards + j * (hieghtFileCards + LengthBetweenFileCards));
                AllFiles[i].PictureFile.Size = new Size(hieghtFileCards - 10, hieghtFileCards - 10);
                AllFiles[i].NameFile.Location = new Point(hieghtFileCards, 5);
                AllFiles[i].NameFile.Size = new Size(Width - 50, hieghtFileCards - 10);
                AllFiles[i].BackColor = CardFile.StartColor;
                AllFiles[i].NameFile.BackColor = CardFile.StartColor;

                ShowingFiles.Add(AllFiles[i]);
                PanelForDirectory.Controls.Add(AllFiles[i]);
            }
            for (int i = FirstActiveFileCard, j = 0; i < FirstActiveFileCard + CountofShowingFileCard && i < AllFiles.Count; i++, j++)
            {
                AllFiles[i].DoubleClick += directory_DoubleClick;
                AllFiles[i].PictureFile.DoubleClick += directory_DoubleClick;
                AllFiles[i].NameFile.DoubleClick += directory_DoubleClick;

                AllFiles[i].Click += Selecte_Click;
                AllFiles[i].PictureFile.Click += Selecte_Click;
                AllFiles[i].NameFile.Click += Selecte_Click;

            }
        }
        private void UpButton_Click(object sender, EventArgs e)
        {
            FirstActiveFileCard--;
            FirstActiveFileCard = FirstActiveFileCard < 0 ? 0 : FirstActiveFileCard;
            ClearFiles();
            ShowFiles();
        }
        private void DownButton_Click(object sender, EventArgs e)
        {
            FirstActiveFileCard++;
            FirstActiveFileCard = FirstActiveFileCard > AllFiles.Count - 1 ? --FirstActiveFileCard : FirstActiveFileCard;
            ClearFiles();
            ShowFiles();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            FirstActiveFileCard = 0;
            if (!PathTextbox.Text.Equals("") && PathTextbox.Text.LastIndexOf('\\').Equals(PathTextbox.Text.Length - 1))
            {
                ClearFiles();
                AllFiles.Clear();
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    AllFiles.Add(new CardFile(drive.Name));
                }
                PathTextbox.Text = "";
                ShowFiles();
            }
            else if (!PathTextbox.Text.Equals("") && PathTextbox.Text.LastIndexOf('\\') != PathTextbox.Text.IndexOf('\\'))
            {
                ShowIndirectory(new CardFile(PathTextbox.Text.Substring(0, PathTextbox.Text.LastIndexOf('\\'))));
            }
            else if (!PathTextbox.Text.Equals(""))
            {
                ShowIndirectory(new CardFile(PathTextbox.Text.Substring(0, 1 + PathTextbox.Text.LastIndexOf('\\'))));
            }
        }
        private void CreateDirectoryButton_Click(object sender, EventArgs e)
        {
            new NewDirectoryForm(PathTextbox.Text).ShowDialog();
            ShowIndirectory(new CardFile(PathTextbox.Text));
            DeleteAction.Invoke();
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удаление файлов", "Вы точно хотите удалить данные файлы", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes))
            {
                foreach (CardFile card in AllFiles)
                {
                    if (card.IsClicked)
                    {
                        PanelForDirectory.Controls.Remove(card);
                        PathForDelete.Add(card.Path);
                    }

                }

                Thread DeleteThread = new Thread(new ThreadStart(deleteDirectories));
                DeleteThread.Start();

            }


        }
        private void deleteDirectories()
        {
            List<string> pathfordelete = PathForDelete;

            foreach (string deletepath in pathfordelete)
            {
                if (Directory.Exists(deletepath))
                {
                    try
                    {
                        Directory.Delete(deletepath, true);
                    }
                    catch
                    {

                    }

                }
                else if (new FileInfo(deletepath).Exists)
                {
                    new FileInfo(deletepath).Delete();
                }
            }
            Action act = () => { DeleteReload(); };
            Invoke(act);

        }
        private void Selecte_Click(object sender, EventArgs e)
        {
            if (sender is CardFile)
            {
                (sender as CardFile).Oneclick();
            }
            else if (sender is PictureBox)
            {
                PictureBox pic = sender as PictureBox;
                ((CardFile)pic.Tag).Oneclick();
            }
            else if (sender is Label)
            {
                Label text = sender as Label;
                ((CardFile)text.Tag).Oneclick();

            }
        }
        private void LeftDirectoryPanel_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < ShowingFiles.Count; i++)
            {
                ShowingFiles[i].Size = new Size(Width, hieghtFileCards);

            }
        }

        private void Inicalization()
        {
            BackColor = Color.FromArgb(242, 242, 242);
            MinimumSize = new Size(300, 500);
            Size = new Size(300, 500);
            Controls.Add(PanelForDirectory);
            Controls.Add(PanelForButtons);
            Dock = DockStyle.Fill;

            PanelForDirectory.Controls.Add(UpButton);
            PanelForDirectory.Controls.Add(DownButton);
            // Настройка UpButton
            #region UpButton
            UpButton.FlatStyle = FlatStyle.Popup;
            UpButton.Text = "";
            UpButton.BackgroundImage = Properties.Resources._4510603_arrow_direction_pointer_up_icon;
            UpButton.BackgroundImageLayout = ImageLayout.Stretch;
            UpButton.Size = new Size(30, 30);
            UpButton.Location = new Point(PanelForDirectory.Width - 30, PanelForDirectory.Height - 60);
            UpButton.BackColor = Color.FromArgb(66, 66, 66);
            UpButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            UpButton.Click += UpButton_Click;
            #endregion


            // Настройка DownButton
            #region DownButton
            DownButton.FlatStyle = FlatStyle.Popup;
            DownButton.Text = "";
            DownButton.BackgroundImage = Properties.Resources._4510586_arrow_direction_down_pointer_icon;
            DownButton.BackgroundImageLayout = ImageLayout.Stretch;
            DownButton.Size = new Size(30, 30);
            DownButton.Location = new Point(PanelForDirectory.Width - 30, PanelForDirectory.Height - 30);
            DownButton.BackColor = Color.FromArgb(66, 66, 66);
            DownButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            DownButton.Click += DownButton_Click;
            #endregion
            PanelForButtons.Controls.Add(PathTextbox);
            PanelForButtons.Controls.Add(BackButton);
            PanelForButtons.Controls.Add(CreateDirectoryButton);
            PanelForButtons.Controls.Add(DeleteButton);

            PathTextbox.ReadOnly = true;
            // Настройка BackButton
            #region BackButton
            BackButton.FlatStyle = FlatStyle.Popup;
            BackButton.Text = "Назад";
            BackButton.Size = new Size(80, 30);
            BackButton.Location = new Point(5, 20);
            BackButton.BackColor = Color.FromArgb(255, 255, 255);
            BackButton.Click += BackButton_Click;
            #endregion

            // Настройка CreateDirectory Button
            #region CreateDirectory
            CreateDirectoryButton.FlatStyle = FlatStyle.Popup;
            CreateDirectoryButton.Text = "Создать";
            CreateDirectoryButton.Size = new Size(80, 30);
            CreateDirectoryButton.Location = new Point(175, 20);
            CreateDirectoryButton.BackColor = Color.FromArgb(255, 255, 255);
            CreateDirectoryButton.Click += CreateDirectoryButton_Click;
            #endregion
            // Настройка DeleteButton
            #region DeleteButton
            DeleteButton.FlatStyle = FlatStyle.Popup;
            DeleteButton.Text = "Удалить";
            DeleteButton.Size = new Size(80, 30);
            DeleteButton.Location = new Point(90, 20);
            DeleteButton.BackColor = Color.FromArgb(255, 255, 255);
            DeleteButton.Click += DeleteButton_Click;

            PanelForButtons.BackColor = StartColor;
            PanelForDirectory.BackColor = StartColor;
            PanelForButtons.Dock = DockStyle.Top;
            PanelForDirectory.Dock = DockStyle.Fill;
            PathTextbox.Dock = DockStyle.Bottom;
            PanelForDirectory.Resize += SmallPanel_Resize;
            #endregion
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                AllFiles.Add(new CardFile(drive.Name));
            }
            CountofShowingFileCard = (PanelForDirectory.Height - 50) / (CardFile.StartFont.Height + 10 + LengthBetweenFileCards);

            ShowFiles();
        }
    }
}
