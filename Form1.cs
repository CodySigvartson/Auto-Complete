using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HW14AutoComplete
{
    public partial class Form1 : Form
    {
        Trie myTrie;
        List<string> wordsToDisplay;
        string filePath;
        public Form1()
        {
            InitializeComponent();
            myTrie = new HW14AutoComplete.Trie();
            wordsToDisplay = new List<string>();
            filePath = "C:\\Users\\Cody\\Documents\\Visual Studio 2015\\Projects\\CptS 321 OOP principles\\HW14AutoComplete\\wordsEn.txt";
            importWords();
        }
        public void importWords()
        {
            string[] words = File.ReadAllLines(filePath);
            foreach(string s in words)
            {
                myTrie.addString(s);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            myTrie.clearWords();
            listBox1.Items.Clear();
            if(textBox1.Text != "")
            {
                myTrie.getSubStrings(myTrie.getPrefixNode(textBox1.Text), textBox1.Text);
                wordsToDisplay = myTrie.getWords();
                listBox1.Items.AddRange(wordsToDisplay.ToArray());
            }
        }
    }
}
