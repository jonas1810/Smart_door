using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartDoor
{
    public delegate void ActionDelegate();
    public delegate string CallDelegate(string message);
    public class Door
    {
        ActionDelegate Hello = new ActionDelegate(Timer);
        CallDelegate Call = new CallDelegate(Transfer);
        public static Boolean locked = true;
        public static Boolean DoorOpen = false;
        public static int num;
        public static Boolean runProgram = true;

        static void Main(string[] args)
        {
            //while loop som køre en nogle if statements
            while(runProgram == true)
            {
                Console.WriteLine("1-Unlock door with pin-code");
                Console.WriteLine("2-Activate movement sensor");
                Console.WriteLine("3-Prevent door from closing");
                Console.WriteLine("4-Activate timed lock");
                Console.WriteLine("5-Deactivate timed lock");
                //tager input fra tastatur  og konventere til int
                int choice = Convert.ToInt32(Console.ReadLine());
                // if statements, som bliver aktiveret afhængig int choice
                if (choice == 1)
                {
                    Pin_Lock.PinCheck(num);
                }
                if (choice == 2)
                {
                    if (!Sensor.Movement())
                    {
                        //starter en thread som køre methoden Timer 
                        Task timer = new Task(() => Open());
                        timer.Start();
                    }
                    else 
                    {
                        Console.WriteLine("The door is locked");
                    }
                }
                if (choice == 3)
                {
                    Resistance();
                }
                if (choice == 4)
                {
                    
                }
                if (choice == 5)
                {
                    
                }
            }
        }

        public static void Open()
        {
            //if statement som tjekker om variablen DoorOpen er true
            if (DoorOpen == true)
            {
                Console.WriteLine("The door is already open");
            }
            //if statement som tjekker om variablen DoorOpen er false
            else if (DoorOpen == false)
            {
                //skifter DoorOpen til true og laver en task
                Console.WriteLine("The door opens!");
                DoorOpen = true;
                Task timer = new Task(() => Timer());
            }
        }
        public static string Transfer(string message)
        {
            return message;
        }
        //Funktion som bliver brugt i en Thread som nedtælling før DoorOpen bliver false igen
        public static void Timer()
        {
            Thread.Sleep(5000);
            DoorOpen = false;

        }

        public static void Resistance()
        {
            //hvis DoorOpen er true laver vi en thread
            if (DoorOpen == true)
            {
                Console.WriteLine("Somthing prevented the door from closing!");
                Task timer = new Task(() => Open());
            }
            else if (DoorOpen == false)
            {
                Console.WriteLine("The door is closed");
            }
        }

        public static void LockTimer()
        {
           
        }
    }

    public class Sensor
    {
        public Boolean movement = false;

        public static bool Movement()
        {
            // når Funktionen Movement bliver kaldt, returnere den locked fra klasses Door 
            return Door.locked;
        }
    }

    public class Pin_Lock
    {
        public static int PinCode = 1337;

        public static void PinCheck(int num)
        {
            Console.WriteLine("Enter pin code: ");
            //tager input fra tastatur  og konvertere det til int
            num = Convert.ToInt32(Console.ReadLine());
            //if statement som tjekker om inputtet i num er ens med variablen PinCode
            if (num == PinCode)
            {
                //hvis de er ens bliver locked i klasses Door skiftet til false 
                Door.locked = false;
                Console.WriteLine("door unlocked!");
            }
            else
            {
                Console.WriteLine("Incorrect pin code.");
            }
        }
    }
}