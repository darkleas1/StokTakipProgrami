using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace frameworksimples
{
    public partial class Form1 : Form
    {

        VeriContext context = new VeriContext();
        public Form1()
        {
            InitializeComponent();
        }
        public void verilerigoster()
        {
            dataGridView1.DataSource = context.Beyazesyalar.ToList();



        }
        private void Form1_Load(object sender, EventArgs e)
        {

            timer2.Start();

            timer1.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.Text != "")
            {
                if (comboBox5.Text == "Beyazesyalar")
                {
                    Beyazesya urun = new Beyazesya();
                    urun.Urunisim = textBox1.Text;
                    urun.Urunfiyat = Convert.ToDouble(textBox2.Text);
                    urun.Stokadet = Convert.ToInt32(textBox3.Text);
                    urun.Satistami = Convert.ToBoolean(comboBox1.Text);
                    urun.Kategori = comboBox5.Text;
                    urun.Altkategori = comboBox6.Text;
                    context.Beyazesyalar.Add(urun);
                    context.SaveChanges();

                }
                else if (comboBox5.Text == "Elektronikler")
                {
                    Elektronik urun = new Elektronik();
                    urun.Urunisim = textBox1.Text;
                    urun.Urunfiyat = Convert.ToDouble(textBox2.Text);
                    urun.Stokadet = Convert.ToInt32(textBox3.Text);
                    urun.Satistami = Convert.ToBoolean(comboBox1.Text);
                    urun.Kategori = comboBox5.Text;
                    urun.Altkategori = comboBox6.Text;
                    context.Elektronikler.Add(urun);
                    context.SaveChanges();

                }
                else if (comboBox5.Text == "Sporlar")
                {
                    Spor urun = new Spor();
                    urun.Urunisim = textBox1.Text;
                    urun.Urunfiyat = Convert.ToDouble(textBox2.Text);
                    urun.Stokadet = Convert.ToInt32(textBox3.Text);
                    urun.Satistami = Convert.ToBoolean(comboBox1.Text);
                    urun.Kategori = comboBox5.Text;
                    urun.Altkategori = comboBox6.Text;
                    context.Sporlar.Add(urun);
                    context.SaveChanges();

                }
                else if (comboBox5.Text == "Temizlikler")
                {
                    Temizlik urun = new Temizlik();
                    urun.Urunisim = textBox1.Text;
                    urun.Urunfiyat = Convert.ToDouble(textBox2.Text);
                    urun.Stokadet = Convert.ToInt32(textBox3.Text);
                    urun.Satistami = Convert.ToBoolean(comboBox1.Text);
                    urun.Kategori = comboBox5.Text;
                    urun.Altkategori = comboBox6.Text;
                    context.Temizlikler.Add(urun);
                    context.SaveChanges();

                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız..");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox4.Text == "Elektronik")
            {
                //Eğer Elektronik kategorisindeyse o kategoriden ürün silsin
                var item = context.Elektronikler.Find(Convert.ToInt32(textBox4.Text));
                context.Elektronikler.Remove(item);
                context.SaveChanges();
            }
            else if (comboBox4.Text == "BeyazEşya")
            {
                //Eğer BeyazEşya kategorisindeyse o kategoriden ürün silsin

                var item = context.Beyazesyalar.Find(Convert.ToInt32(textBox4.Text));
                context.Beyazesyalar.Remove(item);
                context.SaveChanges();
            }
            else if (comboBox4.Text == "Spor")
            {
                //Eğer Spor kategorisindeyse o kategoriden ürün silsin

                var item = context.Sporlar.Find(Convert.ToInt32(textBox4.Text));
                context.Sporlar.Remove(item);
                context.SaveChanges();
            }
            else if (comboBox4.Text == "TemizlikAletleri")
            {
                //Eğer Temizlik Aletleri kategorisindeyse o kategoriden ürün silsin

                var item = context.Temizlikler.Find(Convert.ToInt32(textBox4.Text));
                context.Temizlikler.Remove(item);
                context.SaveChanges();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox4.Text == "BeyazEşya")
            {
                
                //Kategori olarak BeyazEşyayı seçtiyse onun alt kategoraisi sıralanması için;;
                var collection = context.Beyazesyalar.ToList();
                comboBox3.Items.Clear();
                foreach (var items in collection)
                {
                    comboBox3.Items.Add(items.Id);
                }
                var item = context.Beyazesyalar.Find(Convert.ToInt32(comboBox3.Text));
                if (item != null)
                {
                    textBox6.Text = item.Urunisim;
                    textBox7.Text = Convert.ToString(item.Urunfiyat);
                    textBox8.Text = Convert.ToString(item.Stokadet);
                    comboBox2.Text = Convert.ToString(item.Satistami);
                    comboBox9.Text = Convert.ToString(item.Kategori);
                    comboBox8.Text = Convert.ToString(item.Altkategori);
                   
                }
                else if (item == null)
                {
                    textBox6.Text = "Ürün Bulunamadı";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    comboBox2.Text = "";
                    comboBox9.Text = "";
                    comboBox8.Text = "";

                }
            }
            else if (comboBox4.Text == "Elektronik")
            {
                
                //Kategori olarak Elektronik seçtiyse onun alt kategoraisi sıralanması için;;
                var collection = context.Elektronikler.ToList();
                comboBox3.Items.Clear();
                foreach (var items in collection)
                {
                    comboBox3.Items.Add(items.Id);
                }
                var item = context.Elektronikler.Find(Convert.ToInt32(comboBox3.Text));
                if (item != null)
                {
                    textBox6.Text = item.Urunisim;
                    textBox7.Text = Convert.ToString(item.Urunfiyat);
                    textBox8.Text = Convert.ToString(item.Stokadet);
                    comboBox2.Text = Convert.ToString(item.Satistami);
                    comboBox9.Text = Convert.ToString(item.Kategori);
                    comboBox8.Text = Convert.ToString(item.Altkategori);
                    
                }
                else if (item == null)
                {
                    textBox6.Text = "Ürün Bulunamadı";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    comboBox2.Text = "";
                    comboBox9.Text = "";
                    comboBox8.Text = "";

                }
            }
            else if (comboBox4.Text == "TemizlikAletleri")
            {
               
                //Kategori olarak Temizlik Aletlerini seçtiyse onun alt kategoraisi sıralanması için;;

                var collection = context.Temizlikler.ToList();
                comboBox3.Items.Clear();
                foreach (var items in collection)
                {
                    comboBox3.Items.Add(items.Id);
                }
                var item = context.Temizlikler.Find(Convert.ToInt32(comboBox3.Text));
                if (item != null)
                {
                    textBox6.Text = item.Urunisim;
                    textBox7.Text = Convert.ToString(item.Urunfiyat);
                    textBox8.Text = Convert.ToString(item.Stokadet);
                    comboBox2.Text = Convert.ToString(item.Satistami);
                    comboBox9.Text = Convert.ToString(item.Kategori);
                    comboBox8.Text = Convert.ToString(item.Altkategori);
                   

                }
                else if (item == null)
                {
                    textBox6.Text = "Ürün Bulunamadı";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    comboBox2.Text = "";
                    comboBox9.Text = "";
                    comboBox8.Text = "";

                }
            }
            else if (comboBox4.Text == "Spor")
            {
                
                //Kategori olarak Spor'u seçtiyse onun alt kategoraisi sıralanması için;;

                var collection = context.Sporlar.ToList();
                comboBox3.Items.Clear();
                foreach (var items in collection)
                {
                    comboBox3.Items.Add(items.Id);
                }
                var item = context.Sporlar.Find(Convert.ToInt32(comboBox3.Text));
                if (item != null)
                {
                    
                    textBox6.Text = item.Urunisim;
                    textBox7.Text = Convert.ToString(item.Urunfiyat);
                    textBox8.Text = Convert.ToString(item.Stokadet);
                    comboBox2.Text = Convert.ToString(item.Satistami);
                    comboBox9.Text = Convert.ToString(item.Kategori);
                    comboBox8.Text = Convert.ToString(item.Altkategori);
                  
                    

                }
                else if (item == null)
                {
                    textBox6.Text = "Ürün Bulunamadı";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    comboBox2.Text = "";
                    comboBox9.Text = "";
                    comboBox8.Text = "";

                }
            }
            else if (comboBox3.Text == "0")
            {
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                comboBox2.Text = "";
                comboBox9.Text = "";
                comboBox8.Text = "";
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
        
            if (comboBox4.Text == "Elektronik")
            {
                if (textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox2.Text != "" && comboBox9.Text != "" && comboBox8.Text != "")
                {
                   
                    var item = context.Elektronikler.Find(Convert.ToInt32(comboBox3.Text));
                    item.Urunisim = textBox6.Text;
                    item.Urunfiyat = Convert.ToDouble(textBox7.Text);
                    item.Stokadet = Convert.ToInt32(textBox8.Text);
                    item.Satistami = Convert.ToBoolean(comboBox2.Text);
                    item.Kategori = comboBox9.Text;
                    item.Altkategori = comboBox8.Text;
                    context.SaveChanges();
                   
                }
                else
                {
                    MessageBox.Show("Yukarıdaki Yerden Ürünün Id'sini seçiniz");
                }

            }
            else if (comboBox4.Text == "BeyazEşya")
            {
                if (textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox2.Text != "" && comboBox9.Text != "" && comboBox8.Text != "")
                {
                   
                    var item = context.Beyazesyalar.Find(Convert.ToInt32(comboBox3.Text));
                    item.Urunisim = textBox6.Text;
                    item.Urunfiyat = Convert.ToDouble(textBox7.Text);
                    item.Stokadet = Convert.ToInt32(textBox8.Text);
                    item.Satistami = Convert.ToBoolean(comboBox2.Text);
                    item.Kategori = comboBox9.Text;
                    item.Altkategori = comboBox8.Text;
                    context.SaveChanges();
                   

                }
                else
                {
                    MessageBox.Show("Yukarıdaki Yerden Ürünün Id'sini seçiniz");
                }
            }
            else if (comboBox4.Text == "Spor")
            {
                if (textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox2.Text != "" && comboBox9.Text != "" && comboBox8.Text != "")
                {
                   
                    var item = context.Sporlar.Find(Convert.ToInt32(comboBox3.Text));
                    item.Urunisim = textBox6.Text;
                    item.Urunfiyat = Convert.ToDouble(textBox7.Text);
                    item.Stokadet = Convert.ToInt32(textBox8.Text);
                    item.Satistami = Convert.ToBoolean(comboBox2.Text);
                    item.Kategori = comboBox9.Text;
                    item.Altkategori = comboBox8.Text;
                    context.SaveChanges();
                  

                }
                else
                {
                    MessageBox.Show("Yukarıdaki Yerden Ürünün Id'sini seçiniz");
                }
            }
            else if (comboBox4.Text == "TemizlikAletleri")
            {
                if (textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox2.Text != "" && comboBox9.Text != "" && comboBox8.Text != "")
                {
                   
                    var item = context.Temizlikler.Find(Convert.ToInt32(comboBox3.Text));
                    item.Urunisim = textBox6.Text;
                    item.Urunfiyat = Convert.ToDouble(textBox7.Text);
                    item.Stokadet = Convert.ToInt32(textBox8.Text);
                    item.Satistami = Convert.ToBoolean(comboBox2.Text);
                    item.Kategori = comboBox9.Text;
                    item.Altkategori = comboBox8.Text;
                    context.SaveChanges();
                   
                }
                else
                {
                    MessageBox.Show("Yukarıdaki Yerden Ürünün Id'sini seçiniz");
                }
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (comboBox5.Text == "Elektronikler")
            {
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Telefon");
                comboBox6.Items.Add("Tablet");
                comboBox6.Items.Add("Bilgisayar");
                comboBox6.Items.Add("Leptop");
                comboBox6.Items.Add("Klimalar");
            }
            else if (comboBox5.Text == "Beyazesyalar")
            {

                comboBox6.Items.Clear();
                comboBox6.Items.Add("Koltuk");
                comboBox6.Items.Add("Masa");
                comboBox6.Items.Add("Sandaliye");
                comboBox6.Items.Add("Yatak");
                comboBox6.Items.Add("Hali");
            }
            else if (comboBox5.Text == "Sporlar")
            {

                comboBox6.Items.Clear();
                comboBox6.Items.Add("DovusSporlari");
                comboBox6.Items.Add("HavaSporlari");
                comboBox6.Items.Add("EngelliSporlar");

            }
            else if (comboBox5.Text == "Temizlikler")
            {

                comboBox6.Items.Clear();
                comboBox6.Items.Add("Deterjan");
                comboBox6.Items.Add("Firca");
                comboBox6.Items.Add("Bez");
            }
            if (comboBox4.Text == "Elektronik")
            {
               
                dataGridView1.DataSource = context.Elektronikler.ToList();


                if (comboBox7.Text == "Telefon")
                {
                    var collection = context.Elektronikler.ToList();


                    dataGridView1.DataSource = context.Elektronikler.Where(x => x.Altkategori == "Telefon").ToList();


                }
                else if (comboBox7.Text == "Tablet")
                {

                    dataGridView1.DataSource = context.Elektronikler.Where(x => x.Altkategori == "Tablet").ToList();

                }
                else if (comboBox7.Text == "Bilgisayar")
                {


                    dataGridView1.DataSource = context.Elektronikler.Where(x => x.Altkategori == "Bilgisayar").ToList();

                }
                else if (comboBox7.Text == "Leptop")
                {


                    dataGridView1.DataSource = context.Elektronikler.Where(x => x.Altkategori == "Leptop").ToList();


                }
                else if (comboBox7.Text == "Klimalar")
                {

                    dataGridView1.DataSource = context.Elektronikler.Where(x => x.Altkategori == "Klimalar").ToList();



                }

                comboBox7.Items.Clear();
                comboBox7.Items.Add("Telefon");
                comboBox7.Items.Add("Tablet");
                comboBox7.Items.Add("Bilgisayar");
                comboBox7.Items.Add("Leptop");
                comboBox7.Items.Add("Klimalar");
            }
            else if (comboBox4.Text == "BeyazEşya")
            {

               
               dataGridView1.DataSource = context.Beyazesyalar.ToList();

               if (comboBox7.Text == "Masa")
               {

                   dataGridView1.DataSource = context.Beyazesyalar.Where(x => x.Altkategori == "Masa").ToList();

               }
                    else if (comboBox7.Text == "Koltuk")
                    {

                        dataGridView1.DataSource = context.Beyazesyalar.Where(x => x.Altkategori == "Koltuk").ToList();

                    }
                    else if (comboBox7.Text == "Sandaliye")
                    {

                        dataGridView1.DataSource = context.Beyazesyalar.Where(x => x.Altkategori == "Sandaliye").ToList();

                    }
                    else if (comboBox7.Text == "Yatak")
                    {

                        dataGridView1.DataSource = context.Beyazesyalar.Where(x => x.Altkategori == "Yatak").ToList();

                    }
                    else if (comboBox7.Text == "Hali")
                    {

                        dataGridView1.DataSource = context.Beyazesyalar.Where(x => x.Altkategori == "Hali").ToList();

                    }
                
                comboBox7.Items.Clear();
                comboBox7.Items.Add("Koltuk");
                comboBox7.Items.Add("Masa");
                comboBox7.Items.Add("Sandaliye");
                comboBox7.Items.Add("Yatak");
                comboBox7.Items.Add("Hali");
            }
            else if (comboBox4.Text == "Spor")
            {

                    dataGridView1.DataSource = context.Sporlar.ToList();

                    if (comboBox7.Text == "DovusSporlari")
                    {

                        dataGridView1.DataSource = context.Sporlar.Where(x => x.Altkategori == "DovusSporlari").ToList();

                    }
                    else if (comboBox7.Text == "HavaSporlari")
                    {

                        dataGridView1.DataSource = context.Sporlar.Where(x => x.Altkategori == "HavaSporlari").ToList();

                    }
                    else if (comboBox7.Text == "EngelliSporlar")
                    {

                        dataGridView1.DataSource = context.Sporlar.Where(x => x.Altkategori == "EngelliSporlar").ToList();

                    }
        
                comboBox7.Items.Clear();
                comboBox7.Items.Add("DovusSporlari");
                comboBox7.Items.Add("HavaSporlari");
                comboBox7.Items.Add("EngelliSporlar");

            }
            else if (comboBox4.Text == "TemizlikAletleri")
            {

                dataGridView1.DataSource = context.Temizlikler.ToList();

                if (comboBox7.Text == "Deterjan")
                {

                    dataGridView1.DataSource = context.Temizlikler.Where(x => x.Altkategori == "Deterjan").ToList();

                }
                else if (comboBox7.Text == "Firca")
                {

                    dataGridView1.DataSource = context.Temizlikler.Where(x => x.Altkategori == "Firca").ToList();

                }
                else if (comboBox7.Text == "Bez")
                {


                    dataGridView1.DataSource = context.Temizlikler.Where(x => x.Altkategori == "Bez").ToList();

                }
           
                comboBox7.Items.Clear();
                comboBox7.Items.Add("Deterjan");
                comboBox7.Items.Add("Firca");
                comboBox7.Items.Add("Bez");
            }
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox7.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox4.Text = "";
        }
    }
}

    
    

