using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YMG_202503078;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace YMG_202503078
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }



        interface Banking
        {
            double bankingCalculate();

        }

        public class YıllıkYüzdeGetirisi : Banking
        {



            double r;
            int n;

           
            public double bankingCalculate()
            {
                return Math.Pow((1 + (r / 100) / n), n) - 1;
            }
        }

        internal class BalonKredi : Banking
        {
            static public String pv, ba, R, N;
            private double PV = Convert.ToDouble(pv);
            private double BA = Convert.ToDouble(ba);
            private double r = Convert.ToDouble(R);
            private double n = Convert.ToDouble(N);
            public double bankingCalculate()
            {
                return (PV - (BA / Math.Pow(1 + r / 10000, r))) * ((r / 10000) / 1 - Math.Pow(1 + r / 10000, n));
            }
        }

        class KredideKalanBakiye : Banking
        {
            private double PV, P, r;
            int n;

            public void setValues(double PV, double P, double r, int n)
            {
                this.PV = PV;
                this.P = P;
                this.r = r;
                this.n = n;

            }

            public double bankingCalculate()
            {
                return (PV * Math.Pow(1 + r, n)) - (P * ((Math.Pow(1 + r, -n) - 1) / r));
            }
        }


        interface GeneralFinance
        {
            double generalFinanceCalculate();
        }

        class gelecektekiDeğer : GeneralFinance
        {
            private double P, r;
            private int n;
            public void setValues(double P, double r, int n)
            {
                this.P = P;
                this.r = r;
                this.n = n;
            }

            public double generalFinanceCalculate()
            {
                return P * ((Math.Pow(1 + r, n) - 1) / r);
            }

        }


        class İkiyeKatlamaSüresi : GeneralFinance
        {
            private double r;

            public void setR(double r) { this.r = r; }
            public double generalFinanceCalculate()
            {
                return Math.Log(2) / Math.Log(1 + r / 100);
            }
        }

        class AnüiteninBugünküDeğeri : GeneralFinance
        {
            private double P, r;
            private int n;

            public void setValues(double P, double r, int n)
            {
                this.P = P;
                this.r = r;
                this.n = n;
            }

            public double generalFinanceCalculate()
            {
                return P * (1 - Math.Pow(1 + r, -n) / r);
            }
        }


        interface StockBond
        {
            double stockBondCalculate();
        }


        class HisseBaşınaDefter : StockBond
        {
            private double toplamÖzkaynak, hissedarSayısı;
            public void setValues(double tÖ, double hS)
            {
                toplamÖzkaynak = tÖ;
                hissedarSayısı = hS;
            }

            public double stockBondCalculate()
            {
                return toplamÖzkaynak / hissedarSayısı;
            }
        }

        class SermayeKazançGetirisi : StockBond
        {
            private double P1, P0;
            public void setValues(double P1, double P0)
            {
                this.P1 = P1;
                this.P0 = P0;
            }


            public double stockBondCalculate()
            {
                return (P1 - P0) / P0;
            }
        }


        class VergiEşdeğeriGetiri : StockBond
        {
            private double vergisizGetiri, vergiOranı;

            public void getValues(double vg, double vO)
            {
                vergisizGetiri = vg;
                vergiOranı = vO;
            }

            public double stockBondCalculate()
            {
                return vergisizGetiri / (1 - vergiOranı);
            }

        }


        interface AbstractFactory
        {
            Banking getFormula(String formula);
            GeneralFinance getGeneral(String formula);
            StockBond getStockBond(String formula);


        }

        class BankingFactory : AbstractFactory
        {
            public Banking getFormula(String formula)
            {
                if (formula.Equals("YıllıkYüzdeGetirisi"))
                    return new YıllıkYüzdeGetirisi();
                else if (formula.Equals("BalonKredi"))
                    return new KredideKalanBakiye();
                else if (formula.Equals("KalanBakiye"))
                    return new KredideKalanBakiye();

                else return null;

            }
            public GeneralFinance getGeneral(String formula) { return null; }
            public StockBond getStockBond(String formula) { return null; }
        }

        class GeneralFinanceFactory : AbstractFactory
        {
            public GeneralFinance getGeneral(String formula)
            {

                if (formula.Equals("gelecektekiDeğer"))
                    return new gelecektekiDeğer();
                else if (formula.Equals("ikiyeKatlamaSüresi"))
                    return new İkiyeKatlamaSüresi();
                else if (formula.Equals("anüiteninBugünküDeğeri"))
                    return new AnüiteninBugünküDeğeri();

                else return null;
            }

            public StockBond getStockBond(String formula) { return null; }
            public Banking getFormula(String formula) { return null; }
        }


        class StockBondFactory : AbstractFactory
        {
            public StockBond getStockBond(String formula)
            {
                if (formula.Equals("hisseBaşınaDefter"))
                    return new HisseBaşınaDefter();
                else if (formula.Equals("sermayeKazançGetirisi"))
                    return new SermayeKazançGetirisi();
                else if (formula.Equals("vergiEşdeğeriGetiri"))
                    return new VergiEşdeğeriGetiri();

                else return null;
            }
            public Banking getFormula(String formula) { return null; }
            public GeneralFinance getGeneral(String formula) { return null; }
        }

        class FactoryCreator
        {
            static public AbstractFactory getFactory(String seç)
            {

                if (seç.Equals("banking"))
                    return new BankingFactory();
                else if (seç.Equals("generalFinance"))
                    return new GeneralFinanceFactory();
                else if (seç.Equals("stockBond"))
                    return new StockBondFactory();
                else return null;

            }

        }




    }//ns




    private void button1_Click(object sender, EventArgs e)
        {
            

           
            
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        private void Form4_Load(object sender, EventArgs e)
        {

        }

    }



   
}
