using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Encrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ToCrypt = "";
                double key = 1542;
                richTextBox2.Text = "";
                foreach (char c in richTextBox1.Text)
                {
                    char encrypted = (char)(c + key);
                    ToCrypt += encrypted.ToString();
                }
                string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(ToCrypt));

                string plainText = encoded;
                string passPhrase = textBox2.Text;
                string saltValue = "hackflag.salt";
                string hashAlgorithm = "SHA1";
                int passwordIterations = 2;
                string initVector = "@1B2c3D4e5F6g7H8";
                int keySize = 256;
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                           passPhrase,
                                                           saltValueBytes,
                                                           hashAlgorithm,
                                                           passwordIterations);
                byte[] keyBytes = password.GetBytes(keySize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                             keyBytes,
                                                             initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                        encryptor,
                                                        CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                string final = Convert.ToBase64String(cipherTextBytes);

                richTextBox2.Text = final;
            }
            catch (Exception)
            {
                MessageBox.Show("Het coderen van uw gegevens is niet gelukt!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ToDecrypt = richTextBox1.Text;

                string plainText = ToDecrypt;
                string passPhrase = textBox2.Text;
                string saltValue = "hackflag.salt";
                string hashAlgorithm = "SHA1";
                int passwordIterations = 2;
                string initVector = "@1B2c3D4e5F6g7H8";
                int keySize = 256;
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] cipherTextBytes = Convert.FromBase64String(ToDecrypt);
                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                            passPhrase,
                                                            saltValueBytes,
                                                            hashAlgorithm,
                                                            passwordIterations);
                byte[] keyBytes = password.GetBytes(keySize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                             keyBytes,
                                                             initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                          decryptor,
                                                          CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                       0,
                                                       plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                ToDecrypt = Encoding.UTF8.GetString(plainTextBytes,
                                                       0,
                                                       decryptedByteCount);

                string decode = "";
                double key = 1542;
                byte[] encodedDataAsBytes = System.Convert.FromBase64String(ToDecrypt);
                ToDecrypt = System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
                foreach (char c in ToDecrypt)
                {
                    char encrypted = (char)(c - key);
                    decode += encrypted.ToString();
                }
                richTextBox2.Text = decode;
            }
            catch (Exception)
            {
                MessageBox.Show("Het wachtwoord is onjuist!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string export = textBox2.Text;
                File.WriteAllText("export.txt", export);
                MessageBox.Show("Het exporteren is gelukt!");
            }
            catch (Exception)
            {
                MessageBox.Show("Het exporteren is NIET gelukt!");
            }
        }
    }
}
