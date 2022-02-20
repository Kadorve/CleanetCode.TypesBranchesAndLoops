Console.WriteLine("Добро пожаловать в игру 'Угадай число'!");
string? userNameInput = string.Empty;
bool isValidName = false;
int userNameNumber = -1;

do
{
    Console.WriteLine("Пожалуйста, представтесь.");
    userNameInput = Console.ReadLine().Trim();
    if (string.IsNullOrEmpty(userNameInput))
    {
        Console.WriteLine("Ваше имя не должно быть пустым.\n");
    }
    else if(int.TryParse(userNameInput, out userNameNumber))
    {
        Console.WriteLine("Ваше имя не должно быть числом.\n");
    }
    else
    {
        isValidName = true;
    }
   
} while (!isValidName);

Console.WriteLine($"\nПривет, {userNameInput}!");

int minSecretNumberValue = 0;
int maxSecretNumberValue = 999;
Random random = new Random();
int secretNumber = random.Next(minSecretNumberValue, maxSecretNumberValue + 1);
Console.WriteLine(secretNumber);
Console.WriteLine("Число загадано!");

bool isWin = false;
int countOfAttempts = 0;
while (!isWin)
{
    int userNumber = -1;
    bool isIntNumber = false;
    bool isWithinInterval = true;
    do
    {
        Console.WriteLine($"\nВведите число в интевале от {minSecretNumberValue} до {maxSecretNumberValue}");
        string? userNumberInput = Console.ReadLine().Trim();
        isIntNumber = int.TryParse(userNumberInput, out userNumber);

        if (!isIntNumber)
        {
            Console.WriteLine($"Введённое значение ({userNumber}) не является целочисленным или отсутсвует.\n");
        }
        else if ((userNumber < minSecretNumberValue) || (userNumber > maxSecretNumberValue))
        {
            Console.WriteLine($"Введенное значение ({userNumber}) находится вне интевала " +
                $"[{minSecretNumberValue}: {maxSecretNumberValue}].\n");
        }
        else
        {
            isWithinInterval = false;
        }

    } while (!isIntNumber | isWithinInterval);
    countOfAttempts++;

    if (userNumber > secretNumber)
    {
        Console.WriteLine($"Ваше число ({userNumber}) больше загаданного.");
    }
    else if (userNumber < secretNumber)
    {
        Console.WriteLine($"Ваше число ({userNumber}) меньше загаданного.");
    }
    else
    {
        isWin = true;
        Console.WriteLine($"Вы угадали число {userNameInput}! Количество затраченных попыток {countOfAttempts}.\n");
    }
}




   


