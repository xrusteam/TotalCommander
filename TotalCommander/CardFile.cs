using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TotalCommander
{

    class CardFile : Panel
    {
        public static Color StartColor = Color.FromArgb(255, 255, 255);
        public static Font StartFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;
        private ContextMenuStrip contextMenuStrip;
        public bool IsClicked { get; set; }

        public Label NameFile { get; set; }
        public PictureBox PictureFile { get; set; }
        public string Path { get; private set; }


        public CardFile(string path)
        {
            IsClicked = false;



            Path = path;
            BackColor = StartColor;


            NameFile = new Label();
            PictureFile = new PictureBox();

            NameFile.AutoSize = false;
            NameFile.Font = StartFont;
            Controls.Add(NameFile);
            Controls.Add(PictureFile);

            NameFile.BackColor = StartColor;
            NameFile.Location = new Point(30, 10);
            NameFile.Tag = this;

            PictureFile.Tag = this;
            PictureFile.Location = new Point(5, 5);
            PictureFile.Size = new Size(20, 20);


            PictureFile.BackgroundImageLayout = ImageLayout.Stretch;
            if (Directory.Exists(path))
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                NameFile.Text = directory.Name;
                PictureFile.BackgroundImage = Properties.Resources._87682_directory_inode_icon;
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.Name.Equals(path))
                    {
                        NameFile.Text = drive.Name;
                        PictureFile.BackgroundImage = Properties.Resources.out_hdd_767x767;

                        break;
                    }
                }



            }
            else if (File.Exists(path))
            {
                FileInfo file = new FileInfo(path);
                NameFile.Text = file.Name;
               PictureFile.BackgroundImage = Properties.Resources._4115232_dicument_doc_file_paper_icon;


            }
            contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Свойсва");
            contextMenuStrip.ShowImageMargin = false;
            contextMenuStrip.Items.Add(copyMenuItem);
            ContextMenuStrip = contextMenuStrip;
            PictureFile.ContextMenuStrip = contextMenuStrip;
            NameFile.ContextMenuStrip = contextMenuStrip;
            copyMenuItem.Click += CopyMenuItem_Click;


        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            ShowFileProperties(Path);
        }

        public void Oneclick()
        {
            if (IsClicked)
            {
                BackColor = StartColor;
                NameFile.BackColor = StartColor;
            }
            else
            {
                BackColor = Color.FromArgb(200, 200, 200);
                NameFile.BackColor = Color.FromArgb(200, 200, 200);
            }
            IsClicked = !IsClicked;
        }
        public string[] GetDirectories()
        {

            try
            {
                string[] str = Directory.GetDirectories(Path); ;
                return str;
            }
            catch
            {
                return null;
            }

        }
        public FileInfo[] GetFiles()
        {
            try
            {
                FileInfo[] files = new DirectoryInfo(Path).GetFiles();
                return files;
            }
            catch
            {
                return null;
            }

        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }


        public static bool ShowFileProperties(string Filename)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = Filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            return ShellExecuteEx(ref info);
        }

    }
}
