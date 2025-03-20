using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите год: ");
        int year = Convert.ToInt32(Console.ReadLine());

        string[] animals = {
            "Крыса",
            "Бык",    
            "Тигр", 
            "Кролик",
            "Дракон",
            "Змея",    
            "Лошадь",  
            "Овца",    
            "Обезьяна", 
            "Петух",   
            "Собака",  
            "Кабан"    
        };

        int index = (year - 1924) % 12; 
        if (index < 0)
        {
            index += 12; 
        }

        Console.WriteLine($"Год {year} символизирует животное: {animals[index]}.");
    }
}