# Smart_door
Jonas Simonsen

Synopsis 

Mit projekt er en smart-dør, som er simuleret i commands line. 
Main thread køre et while loop, som looper nogle writelines som beskriver hvilket input du skal give for at aktivere de forskellige if statements. 

Code exaple

While loop som køre imens runProgram er true.
while(runProgram == true)
            {
                Console.WriteLine("1-Unlock door with pin-code");
                Console.WriteLine("2-Activate movement sensor");
                Console.WriteLine("3-Prevent door from closing");
                Console.WriteLine("4-Activate timed lock");
                Console.WriteLine("5-Deactivate timed lock");

Readline som bestemmer værdien af int choice
int choice = Convert.ToInt32(Console.ReadLine()); If statements som starter afhængig af int choice 
F.eks
if (choice == 1)
kalder den methoden fra fra klassen Pin_Lock som hedder PinCheck
som spørger efter en pinkode og tjekker om input er det samme som variablen int PinCode som har værdien 1337.
