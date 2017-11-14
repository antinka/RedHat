using System;
using System.Text;

namespace RedHat
{   public delegate void MessageWaySmbInWood(string str);


    class Program
    {
      

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
           
            Console.WriteLine("Жили были :");
            Grandmother grandMa = new Grandmother();
            Mother mother = new Mother();
            RedHat redHat = new RedHat();
            Wolf wolf = new Wolf();
      
            Console.WriteLine(grandMa.Name+", " + mother.Name+", "+ redHat.Name+" и "+ wolf.Name);
            if(mother.CordX==redHat.CordX && mother.CordY == redHat.CordY)
            {
                mother.GiveBasket(mother.Name, redHat.Name, grandMa.Name);
            }
           redHat.CordinateRedHat += wolf.RedHaInWood;
            do
            {
               if (wolf.noticeRedHat == true)
                {
                    wolf.GoToRedHat(redHat.CordX, redHat.CordY, redHat.Name);
                    wolf.TalkWithRedHat(redHat.TalkWithWolf(wolf.TalkWithRedHat(redHat.TalkWithWolf( wolf.TalkWithRedHat()))));
                    redHat.CordinateRedHat -= wolf.RedHaInWood;
                    wolf.noticeRedHat = false;
                }
                wolf.Move();
               redHat.Move();
              

            } while (wolf.reachedHouse==false && redHat.reachedHouse == false);

            if (wolf.reachedHouse == true && redHat.reachedHouse == false)
            {
                wolf.FirstInHouse();
            }
            else
            {
                if (grandMa.CordX == redHat.CordX && grandMa.CordY == redHat.CordY)
                {
                    grandMa.TakeBasket(redHat.Name);
                }
                wolf.SecondInHouse(redHat.Name);

            }

           
        }
    }
   
    abstract class Сharacters
    {
        public string Name { get; set; }
        public int CordX { get; set; }
        public int CordY { get; set; }
        public int Speed { get; set; }

       public Random rnd = new Random();

        public virtual void Move()
        {
            if (CordX < 100 && CordY < 100)
            {
                CordX += rnd.Next(0, Speed / 2);
                CordY += rnd.Next(0, Speed / 2);
            }
            else if(CordX >= 100 && CordY >= 100)
             {
                    CordY = 100;
                    CordX = 100;
             }
            else 
            {
                if(CordX >= 100)
                {
                CordY += rnd.Next(0, Speed / 2);
                CordX = 100;
                }
                else 
                {
                    CordY = 100;
                    CordX += rnd.Next(0, Speed / 2);
                }      
            }
        }
    }
    class Grandmother : Сharacters
    {
        public Grandmother()
        {
            Name = "Бабушка";
            CordX = 100;
            CordY = 100;
            Speed = 30;

        }
        public void TakeBasket(string fromWho)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine($"добралась {fromWho} к дому где живет ее {Name} и передала ей корзинку с лакомствами");
        }
    }
    class Mother : Сharacters
    {
        public Mother()
        {
            Name = "Мама";
            CordX = 0;
            CordY = 0;
            Speed = 40;
        }
        public void GiveBasket(string who, string whom, string toWhomCarry)
        {
            Console.WriteLine($" позвала {who} {whom}(у), да и говорит \n - {whom}, ступай-ка навести {toWhomCarry}(у). Положу я тебе в корзинку кусок пирога и бутылку молока, отнесёшь это ей");
        }
    }
    class RedHat : Сharacters
    {
        public event MessageWaySmbInWood CordinateRedHat;
        public RedHat()
        {
            Name = "Красная шапочка";
            CordX = 0;
            CordY = 0;
            Speed = 90;
        }
        public bool reachedHouse = false;
        public override void Move()
        {

            base.Move();

            Console.WriteLine($"идет {Name} {CordX} {CordY}");

            if (CordX > 25 && CordX < 75 && CordY > 25 && CordY < 75)
            {
                if (CordinateRedHat != null)
                {
                    CordinateRedHat.Invoke($"{Name}(у) в лесу");
                }
            }
            else if(CordX==100 && CordY ==100)
            {
                reachedHouse = true;
            }
        }
        public string TalkWithWolf(string msg)
        {
            if (msg == "Девочка, девочка куда ты идешь?")
            {
                Console.WriteLine("- К бабушке ");
                return "К бабушке";
            }
            else if (msg == "а где она живет")
            {
                Console.WriteLine("-Чуть дальше леса, под тремя большими дубами стоит её домик");
                return "Чуть дальше леса, под тремя большими дубами стоит её домик";
            }
            else
                return "";
        }
    }
    class Wolf : Сharacters
    {
        public Wolf()
        {
            Name = "Серый волк";
            CordX = 25;
            CordY = 25;
            Speed = 50;
        }
        public bool noticeRedHat = false;
        private bool run = false;
        public void RedHaInWood(string str)
        {
            Console.WriteLine($"{Name} заметил {str} ");
            noticeRedHat = true;
            run = true;
        }
        public bool reachedHouse = false;
        public override void Move()
        {
            base.Move();
            if (run == true)
            {
                Console.WriteLine($"бежит {Name} {CordX} {CordY}");
            }
            else
            {
                Console.WriteLine($"гуляет по лесу {Name} {CordX} {CordY}");
            }
            if (CordX == 100 && CordY == 100)
            {
                reachedHouse = true;
            }
        }
        public void FirstInHouse()
        {
          Console.WriteLine($"и добрался {Name} к дому бабушки, представился ее внучкой и зайдя в дом съел ее, да и убежал, пока его никто не заметил"); 
        }
        public void SecondInHouse(string name)
        {
            Console.WriteLine($"чуть позже добрался и {Name} к дому бабушки, представился ее внучкой,сказав что принес ей корзинку , но не знал {Name}  что,{name} уже у бабушки. \n Не получилось у {Name} попасть в дом бабушки, он расстроился и ушел прочь");
        }
            public void GoToRedHat(int x, int y, string toWhom)
        {
            Console.WriteLine($"Побежал  {Name} к {toWhom}(е)");
            CordX =x;
            CordY =y;
        }
        public string TalkWithRedHat()
        {
            Console.WriteLine("- Девочка, девочка куда ты идешь?");
                return "Девочка, девочка куда ты идешь?";
        }
        public string TalkWithRedHat(string msg)
        {
                if (msg == "К бабушке")
                {
                    Console.WriteLine($"- А где она живет?");
                    return "а где она живет";
                }
                else if (msg == "Чуть дальше леса, под тремя большими дубами стоит её домик")
                {
                Console.WriteLine($"-Счастливого пути тебе пожелал {Name}");
                Console.WriteLine($"И побежал {Name} искать где за лесом стоит три дубка, а под ними домик");
                return "";
                }
                else
                    return "";

            }
    }

}
