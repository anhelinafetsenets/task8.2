using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8._2
{
        public enum Grade { Highest, First, Second };
        public enum Kind { Mutton, Veal, Pork, Chicken };

        public class Product
        {
            protected double[] GradePercent = new double[] { 0, 5, 7 };
            protected string sName;

            public string Name
            {
                get { return sName; }
                set { sName = value; }
            }


            protected double fPrice;

            public double Price
            {
                get { return fPrice; }
                set { fPrice = value; }
            }


            protected double fWeight;

            public double Weight
            {
                get { return fWeight; }
                set { fWeight = value; }
            }

            public Product()
            {
                sName = "product";
                fPrice = 0;
                fPrice = 0;
            }
            public Product(string sName, double fPrice, double fWeight)
            {
                this.sName = sName;
                this.fPrice = fPrice;
                this.fWeight = fWeight;
            }

            public Product(string line)
            {
                string[] subs = line.Split(" ");
                this.sName = subs[0];
                try
                {
                    this.fPrice = Convert.ToDouble(subs[1]);
                    this.fWeight = Convert.ToDouble(subs[2]);
                }
                catch (Exception)
                {

                }
            }
            public override string ToString()
            {
                return sName + " " + fPrice + "UAH  " + fWeight + "kg\n";
            }

            public override bool Equals(object obj)
            {
                if (obj == null || this.GetType() != obj.GetType())
                    return false;
                Product p = (Product)obj;
                if (this.sName == p.sName)
                    return true;
                else return false;
            }

            public virtual void PriceUp(double percentUp)
            {
                fPrice += fPrice * percentUp / 100;
            }

            public virtual void PriceDown(double percentUp)
            {
                fPrice -= fPrice * percentUp / 100;
            }

            public static int CompareByName(Product a, Product b)
            {
                if (String.Compare(a.sName, b.sName) == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            public static int CompareByPrice(Product a, Product b)
            {
                if (a.fPrice < b.fPrice)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(GradePercent, sName, Name, fPrice, Price, fWeight, Weight);
            }
        }

        public class Meat : Product
        {

            private Grade MeatGrade;

            public Grade grade
            {
                get { return MeatGrade; }
                set { MeatGrade = value; }
            }

            private Kind MeatKind;

            public Kind kind
            {
                get { return MeatKind; }
                set { MeatKind = value; }
            }
            public Meat() : base()
            {
                MeatGrade = Grade.Highest;
                MeatKind = Kind.Pork;
            }
            public Meat(string Name, double Price, double Weight, Grade MeatGrade, Kind MeatKind) : base(Name, Price, Weight)
            {
                this.MeatGrade = MeatGrade;
                this.MeatKind = MeatKind;
            }
            public override bool Equals(object obj)
            {
                if (obj == null || this.GetType() != obj.GetType())
                    return false;
                Meat p = (Meat)obj;
                if (this.sName == p.sName && this.fPrice == p.fPrice && this.fWeight == p.fWeight && this.MeatGrade == p.MeatGrade && this.MeatKind == p.MeatKind)
                    return true;
                else return false;
            }
            public override string ToString()
            {
                return sName + " " + fPrice + "UAH  " + fWeight + "kg  " + MeatGrade + "  " + MeatKind + " \n";
            }
            public override void PriceUp(double percentUp)
            {
                switch (MeatGrade)
                {
                    case Grade.Highest:
                        {
                            percentUp += GradePercent[2];
                            break;
                        }
                    case Grade.First:
                        {
                            percentUp += GradePercent[1];
                            break;
                        }
                    case Grade.Second:
                        {
                            percentUp += GradePercent[0];
                            break;
                        }
                    default: break;
                }
                fPrice += fPrice * percentUp / 100;

            }

            public override void PriceDown(double percentUp)
            {
                fPrice -= fPrice * percentUp / 100;
            }

            public override int GetHashCode()
            {
                HashCode hash = new HashCode();
                hash.Add(base.GetHashCode());
                hash.Add(GradePercent);
                hash.Add(sName);
                hash.Add(Name);
                hash.Add(fPrice);
                hash.Add(Price);
                hash.Add(fWeight);
                hash.Add(Weight);
                hash.Add(MeatGrade);
                hash.Add(grade);
                hash.Add(MeatKind);
                hash.Add(kind);
                return hash.ToHashCode();
            }
        }
        public class Dairy_products : Product
        {
            private int ExpTerm;
            public int expterm
            {
                get { return ExpTerm; }
                set { ExpTerm = value; }
            }
            public Dairy_products() : base()
            {
                ExpTerm = 1;
            }
            public Dairy_products(string sName, double fPrice, double fWeight, int ExpTerm) : base(sName, fPrice, fWeight)
            {
                this.ExpTerm = ExpTerm;
            }
            public override string ToString()
            {
                return sName + " " + fPrice + "UAH  " + fWeight + "kg  SHELF LIFE  " + ExpTerm + " days\n";
            }
            public override bool Equals(object obj)
            {
                if (obj == null || this.GetType() != obj.GetType())
                    return false;
                Dairy_products p = (Dairy_products)obj;
                if (this.sName == p.sName && this.fPrice == p.fPrice && this.fWeight == p.fWeight && this.ExpTerm == p.ExpTerm)
                    return true;
                else return false;
            }

            public override void PriceUp(double percentUp)
            {
                if (ExpTerm <= 10)
                {
                    percentUp += GradePercent[0];
                }
                else if (ExpTerm >= 10 || ExpTerm <= 62)
                {
                    percentUp += GradePercent[1];
                }
                if (ExpTerm > 62)
                {
                    percentUp += GradePercent[2];
                }

                fPrice += fPrice * percentUp / 100;

            }

            public override void PriceDown(double percentUp)
            {
                fPrice -= fPrice * percentUp / 100;
            }

            public override int GetHashCode()
            {
                HashCode hash = new HashCode();
                hash.Add(base.GetHashCode());
                hash.Add(GradePercent);
                hash.Add(sName);
                hash.Add(Name);
                hash.Add(fPrice);
                hash.Add(Price);
                hash.Add(fWeight);
                hash.Add(Weight);
                hash.Add(ExpTerm);
                hash.Add(expterm);
                return hash.ToHashCode();
            }
        }

        public class Buy
        {
            private Product cProduct;
            public Product prod;

            public Product prdct
            {
                get { return prod; }
                set { prod = value; }
            }

            private int dAmount;

            public int Amount
            {
                get { return dAmount; }
                set { dAmount = value; }
            }

            public Buy()
            {
                dAmount = 1;
                cProduct = new Product();
            }
            public Buy(Product Prod, int dAmount)
            {
                this.dAmount = dAmount;
                cProduct = Prod;
            }
            public void PrintCheck()
            {
                Console.WriteLine($"{Amount} * {cProduct.ToString()} ");
            }
            public override string ToString()
            {
                return $"{Amount} * {cProduct.ToString()} ";
            }

            public override bool Equals(object obj)
            {
                return obj is Buy buy &&
                       EqualityComparer<Product>.Default.Equals(cProduct, buy.cProduct) &&
                       EqualityComparer<Product>.Default.Equals(prod, buy.prod) &&
                       EqualityComparer<Product>.Default.Equals(prdct, buy.prdct) &&
                       dAmount == buy.dAmount &&
                       Amount == buy.Amount;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(cProduct, prod, prdct, dAmount, Amount);
            }
        }
        sealed public class Check
        {
            public void ToString(Buy b)
            {
                b.ToString();
            }

        }

        public class Storage
        {
            private Product[] products;

            public Product[] Products
            {
                get { return products; }

            }


            int size;
            Grade GetGrade(int i)
            {
                Grade grad = Grade.Highest;
                switch (i)
                {
                    case 0:
                        {
                            grad = Grade.Highest;
                            break;
                        }
                    case 1:
                        {
                            grad = Grade.First;
                            break;
                        }
                    case 2:
                        {
                            grad = Grade.Second;
                            break;
                        }
                    default:
                        {
                            grad = Grade.Highest;
                            break;
                        }

                }
                return grad;
            }
            Kind GetKind(int i)
            {
                Kind kind = Kind.Mutton;
                switch (i)
                {
                    case 0:
                        {
                            kind = Kind.Mutton;
                            break;
                        }
                    case 1:
                        {
                            kind = Kind.Veal;
                            break;
                        }
                    case 2:
                        {
                            kind = Kind.Pork;
                            break;
                        }
                    case 3:
                        {
                            kind = Kind.Chicken;
                            break;
                        }
                    default:
                        {
                            kind = Kind.Mutton;
                            break;
                        }

                }
                return kind;
            }
            public Storage()
            {
                Console.WriteLine("Enter amount of products: ");
                size = Convert.ToInt32(Console.ReadLine());
                products = new Product[size];


            }

            public void Create()
            {

                for (int i = 0; i < size; ++i)
                {
                    Console.WriteLine("Meat(1), dairy(2) or other(3)?");
                    int type = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter name of product: ");
                    string nm = Console.ReadLine();
                    Console.WriteLine("Enter price: ");
                    double pr = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter weight: ");
                    double wgh = Convert.ToDouble(Console.ReadLine());
                    switch (type)
                    {
                        case 1:
                            {
                                Console.WriteLine(" Enter grade: Highest(0), First(1), Second(2): ");
                                int grd = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(" Enter kind: Mutton(0), Veal(1), Pork(2), Chicken(3): ");
                                int knd = Convert.ToInt32(Console.ReadLine());
                                products[i] = new Meat(nm, pr, wgh, GetGrade(grd), GetKind(knd));
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine(" Enter shell life(days) ");
                                int sl = Convert.ToInt32(Console.ReadLine());
                                products[i] = new Dairy_products(nm, pr, wgh, sl);
                                break;

                            }
                        default:
                            {
                                products[i] = new Product(nm, pr, wgh);
                                break;
                            }
                    }
                }
            }

            public void Print_All()
            {
                for (int i = 0; i < size; ++i)
                {
                    Console.WriteLine(Convert.ToString(products[i]));
                }
            }
            public void SearchMeat()
            {
                Console.WriteLine("MEAT:\n");
                for (int i = 0; i < size; ++i)
                {
                    if (products[i] is Meat)
                    {
                        Console.WriteLine(Convert.ToString(products[i]));
                    }
                }
            }
            public void ChangePriceUp(double percent)
            {
                for (int i = 0; i < size; ++i)
                {
                    products[i].PriceUp(percent);
                }
            }
            public void ChangePriceDown(double percent)
            {
                for (int i = 0; i < size; ++i)
                {
                    products[i].PriceDown(percent);
                }
            }
            public Product this[int i]
            {
                get
                {
                    return (Product)products[i];
                }


                set
                {
                    products[i] = value;
                }
            }

        }
    

}
