using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;



//abFactory Pattern Kullanılmıştır.

namespace YMG_202503078
{

    public interface Banking
    {
        double bankingCalculate();

    }

    public class YıllıkYüzdeGetirisi : Banking
    {

        public static String R;
        public static String N;
        public double r = Convert.ToDouble(R);
        int n = Convert.ToInt16(N);

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
        public static String pv, p, R, N;
        private double PV = Convert.ToDouble(pv);
        private double P = Convert.ToDouble(p);
        private double r = Convert.ToDouble(R);
        private int n = Convert.ToInt16(N);



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
        public static String p, R,N;
        
        private double P=Convert.ToDouble(p);
        private double r = Convert.ToDouble(R); 
        private int n = Convert.ToInt16(N);

    
        public double generalFinanceCalculate()
        {
            return P * ((Math.Pow(1 + r, n) - 1) / r);
        }

    }


    class İkiyeKatlamaSüresi : GeneralFinance
    {
        public static String R;
        private double r=Convert.ToDouble(R);

      
        public double generalFinanceCalculate()
        {
            return Math.Log(2) / Math.Log(1 + r / 100);
        }
    }

    class AnüiteninBugünküDeğeri : GeneralFinance
    {
        public static String    p,R,N;
        private double P = Convert.ToDouble(p);
        private double r =Convert.ToDouble(R);
        private int n =Convert.ToInt16(N);

      
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
        public static String tÖ, hS;

        private double toplamÖzkaynak = Convert.ToDouble(tÖ);

        private double hissedarSayısı = Convert.ToDouble(hS); 
       
     

        public double stockBondCalculate()
        {
            return toplamÖzkaynak / hissedarSayısı;
        }
    }

    class SermayeKazançGetirisi : StockBond
    {
        public static String p1, p0;
        private double P1=Convert.ToDouble(p1);
        private double P0=Convert.ToDouble(p0);
        
        

        public double stockBondCalculate()
        {
            return (P1 - P0) / P0;
        }
    }


    class VergiEşdeğeriGetiri : StockBond
    {
        public static  String vG, vO;

        private double vergisizGetiri=Convert.ToDouble(vG);

        private double vergiOranı=Convert.ToDouble(vO);

    

        public double stockBondCalculate()
        {
            return vergisizGetiri / (1 - vergiOranı);
        }

    }


    interface AbstractFactory
    {
        Banking createBanking(String formula);
        GeneralFinance createGeneral(String formula);
        StockBond createStockBond(String formula);


    }

    class BankingFactory : AbstractFactory
    {
        public Banking createBanking(String formula)
        {
            if (formula.Equals("YıllıkYüzdeGetirisi"))
                return new YıllıkYüzdeGetirisi();
            else if (formula.Equals("BalonKredi"))
                return new KredideKalanBakiye();
            else if (formula.Equals("KalanBakiye"))
                return new KredideKalanBakiye();

            else return null;

        }
        public GeneralFinance createGeneral(String formula) { return null; }
        public StockBond createStockBond(String formula) { return null; }
    }

    class GeneralFinanceFactory : AbstractFactory
    {
        public GeneralFinance createGeneral(String formula)
        {

            if (formula.Equals("gelecektekiDeğer"))
                return new gelecektekiDeğer();
            else if (formula.Equals("ikiyeKatlamaSüresi"))
                return new İkiyeKatlamaSüresi();
            else if (formula.Equals("anüiteninBugünküDeğeri"))
                return new AnüiteninBugünküDeğeri();

            else return null;
        }

        public StockBond createStockBond(String formula) { return null; }
        public Banking createBanking(String formula) { return null; }
    }


    class StockBondFactory : AbstractFactory
    {
        public StockBond createStockBond(String formula)
        {
            if (formula.Equals("hisseBaşınaDefter"))
                return new HisseBaşınaDefter();
            else if (formula.Equals("sermayeKazançGetirisi"))
                return new SermayeKazançGetirisi();
            else if (formula.Equals("vergiEşdeğeriGetiri"))
                return new VergiEşdeğeriGetiri();

            else return null;
        }
        public Banking createBanking(String formula) { return null; }
        public GeneralFinance createGeneral(String formula) { return null; }
    }

    class FactoryCreator
    {
        public static AbstractFactory createFactory(String seç)
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
