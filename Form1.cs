using CG.Web.MegaApiClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mega2021Downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void DownloadFileFromUrl(string url)
        {
            var client = new MegaApiClient();
            client.LoginAnonymous();

            Uri folderLink = new Uri("https://mega.nz/#F!e1ogxQ7T!ee4Q_ocD1bSLmNeg9B6kBw");
            IEnumerable<INode> nodes = client.GetNodesFromLink(folderLink);
            foreach (INode node in nodes.Where(x => x.Type == NodeType.File))
            {
                Console.WriteLine($"Downloading {node.Name}");
                client.DownloadFile(node, node.Name);
            }

            client.Logout();
        }
    }
}
