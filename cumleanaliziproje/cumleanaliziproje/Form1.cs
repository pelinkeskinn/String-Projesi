using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cumleanaliziproje
{
    public static class StringExtensions
    {
        public static int kelime(this string text)
        {
          
            return text.Split(new char[] { ' ', '\t', '\n', '\r', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int cumle(this string text)
        {
            char[] sentenceSeparators = { '.', '!', '?' };
            return text.Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string enuzunkelime(this string text)
        {
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return words.OrderByDescending(word => word.Length).FirstOrDefault();
        }

        public static string tersi(this string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string CapitalizeFirstWordInSentences(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < sentences.Length; i++)
            {
                int firstLetterIndex = sentences[i].IndexOfAny(new[] { ' ', '\t', '\n', '\r' });
                if (firstLetterIndex >= 0)
                {
                    sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1, firstLetterIndex - 1) + sentences[i].Substring(firstLetterIndex);
                }
                else
                {
                    sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
                }
            }

            return string.Join(" ", sentences);
        }
    }
        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Lütfen geçerli bir metin girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int wordCount = inputText.kelime();
            int sentenceCount = inputText.cumle();
            string longestWord = inputText.enuzunkelime();
            string reversedLongestWord = longestWord.tersi();

            string capitalizedSentences = inputText.CapitalizeFirstWordInSentences();
            string reversedCapitalizedSentences = capitalizedSentences.tersi();

          
            listBox1.Items.Clear();
            listBox1.Items.Add($"Kelime Sayısı: {wordCount}");
            listBox1.Items.Add($"Cümle Sayısı: {sentenceCount}");
            listBox1.Items.Add($"En Uzun Kelime: {longestWord}");
            listBox1.Items.Add($"En Uzun Kelimenin Tersi: {reversedLongestWord}");
            listBox1.Items.Add($"Kelimelerin baş harfi büyük olmalı: {capitalizedSentences}");

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
