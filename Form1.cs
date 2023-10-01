using System;
using System.Windows.Forms;
using System.IO;

namespace Wimmer
{
	public partial class Wimmer : Form
	{
		private string path;
		public Wimmer(string path = null)
		{
			this.path = path;
			InitializeComponent();
			if (!string.IsNullOrEmpty(path))
			{
				source.Text = File.ReadAllText(path);
				source_TextChanged(null, null);
			}
		}
		private void source_TextChanged(object sender, EventArgs e)
		{
			Browser.DocumentText = source.Text;
		}
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog()
			{
				Multiselect = false,
				ValidateNames = true,
				Filter = "HTML|*.html"
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				path = openFileDialog.FileName;
				source.Text = File.ReadAllText(path);
			}
		}
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(path))
			{
				saveAsToolStripMenuItem_Click(sender, e);
			}
			else
			{
				File.WriteAllText(path, source.Text);
			}
		}
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog()
			{
				ValidateNames = true,
				Filter = "HTML|*.html"
			};
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				path = saveFileDialog.FileName;
				File.WriteAllText(path, source.Text);
			}
		}
	}
}