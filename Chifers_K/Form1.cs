using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chifers_K
{
    public partial class Form1 : Form
    {

        public string cipher = "Ceaser";

        public Form1()
        {
            InitializeComponent();
            btnCeaser.Active = true;
            Chars = true;
            text = false;
        }
        string textToIncryption;
        string Key;
        bool keyRequired()
        {
            if (txtkey.Text == "")
            {
                label5.Visible = true;
                System.Media.SystemSounds.Beep.Play();
                return false;
            }
            else
            {
                label5.Visible = false;
                return true;
            }

        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            textToIncryption = txtNormal.Text;
            Key = txtkey.Text;
            try
            {

            switch (cipher)
            {
                case "Ceaser":
                    if (!keyRequired())
                    {
                        return;
                    }
                    
                    textToIncryption = txtNormal.Text;
                    Key = txtkey.Text;
                    string cipherText = Ceaser.Encipher(textToIncryption, Convert.ToInt32(Key));
                    txtEncrypted.Text = cipherText;
                    txtdecrypted.Text = Ceaser.Decipher(cipherText, Convert.ToInt32(Key));

                    break;
                case "Viegener":
                        
                    if (!keyRequired())
                    {
                        return;
                    }
                    panel1.Visible = true;


                    string VCipher = Vigener.Encipher(textToIncryption, Key);
                    txtEncrypted.Text = VCipher;
                    txtdecrypted.Text = Vigener.Decipher(VCipher, Key);
                    break;
                case "playfair":
                        if (!keyRequired())
                        {
                            return;
                        }
                        panel1.Visible = true;


                        txtEncrypted.Text = playfair.Encipher(txtNormal.Text, txtkey.Text);
                        txtdecrypted.Text = playfair.Decipher(playfair.Encipher(txtNormal.Text, txtkey.Text), txtkey.Text);
                        break;
                case "Railfence":
                    if (!keyRequired())
                    {
                        return;
                    }
                    panel1.Visible = true;

                    
                    txtEncrypted.Text = railFence.Encrypt(txtNormal.Text, Convert.ToInt32(Key));
                        txtdecrypted.Text = railFence.Decrypt(railFence.Encrypt(txtNormal.Text, Convert.ToInt32(Key)), Convert.ToInt32(Key));
                    break;
                case "polyalphatetic":
                    if (!keyRequired())
                    {
                        return;
                    }
                    panel1.Visible = true;


                    string PCipher = new Polyalphabetic().Encrypt(textToIncryption, Key);
                    txtEncrypted.Text = PCipher;
                    txtdecrypted.Text = new Polyalphabetic().Decrypt(PCipher, Key);
                    break;
                case "Monoalphapetic":
                    
                    string key = "zyxwvutsrqponmlkjihgfedcbaABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string MonoCipher = Monoalphaptic.Encrypt(textToIncryption, key);
                    txtEncrypted.Text = MonoCipher;
                    txtdecrypted.Text = Monoalphaptic.Decrypt(MonoCipher, key);
                    
                    break;

            }

            }
            catch (Exception)
            {

                return;
            }

        }

        private void btnCeaser_Click(object sender, EventArgs e)
        {
            txtkey.Text = "";
            txtdecrypted.Text = "";
            txtEncrypted.Text = "";
            cipher = "Ceaser";
            txtkey.Visible = true;
            Chars = true;
            label2.Visible = true;
            text = false;
        }

        private void btnViegener_Click(object sender, EventArgs e)
        {
            txtkey.Text = "";
            txtdecrypted.Text = "";
            txtEncrypted.Text = "";

            cipher = "Viegener";
            txtkey.Visible = true;
            text = true;
            Chars = false;
            label2.Visible = true;
        }

        private void btnPlayFair_Click(object sender, EventArgs e)
        {
            txtkey.Text = "";
            txtdecrypted.Text = "";
            txtEncrypted.Text = "";
            cipher = "playfair";
            txtkey.Visible = true;
            Chars = false;
            text = false;
            label2.Visible = true;
        }

        private void btnPolyalphapetic_Click(object sender, EventArgs e)
        {
            txtkey.Text = "";
            txtdecrypted.Text = "";
            txtEncrypted.Text = "";
            cipher = "polyalphatetic";
            Chars = false;
            text = false;

            txtkey.Visible = true;
            label2.Visible = true;
        }

        private void btnRailfence_Click(object sender, EventArgs e)
        {
            txtkey.Text = "";
            txtdecrypted.Text = "";
            txtEncrypted.Text = "";
            cipher = "Railfence";
            txtkey.Visible = true;
            Chars = true;
            text = false;
            label2.Visible = true;
        }

        private void btnMonoalphapetic_Click(object sender, EventArgs e)
        {
            txtkey.Text = "";
            txtdecrypted.Text = "";
            txtEncrypted.Text = "";
            cipher = "Monoalphapetic";
            txtkey.Visible = false;
            label2.Visible = false;
        }
        Boolean Chars = false;
        Boolean text = false;

        private void txtkey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Chars)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
            if (text)
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
