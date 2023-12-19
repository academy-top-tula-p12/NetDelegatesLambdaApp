
/*
WriteConsole writer = delegate (string messsage)
{
    Console.WriteLine("Hello " + messsage);
};

writer += (string messsage) => Console.WriteLine("Good by " + messsage);


writer("World");
writer?.Invoke("People");
*/

/*
int count = 50;

Console.WriteLine(Calc(10, 20, Sum));
Console.WriteLine(Calc(10, 20, delegate(int a, int b)
{
    return a * b + count;
}));
*/


/*
WriteConsole? writer = WriteHello;
writer.Invoke("World");

writer += WriteGoodBy;
writer.Invoke("People");

writer -= WriteHello;
writer?.Invoke("All");

writer += delegate (string message)
{
    Console.WriteLine($"Wait {message}");
};

writer?.Invoke("Mans");

writer -= delegate (string message)
{
    Console.WriteLine($"Wait {message}");
};

writer?.Invoke("Childrens");



void WriteHello(string message)
{
    Console.WriteLine($"Hello {message}");
}

void WriteGoodBy(string message)
{
    Console.WriteLine($"Good By {message}");
}


int Calc(int a, int b, Operation oper)
{
    return oper(a, b);
}

int Sum(int a, int b)
{
    return a + b;
}

int Sub(int a, int b)
{
    return a - b;
}
*/

Operation oper = (x, y) => x + y;

Console.WriteLine(Calc(10, 20, oper));
Console.WriteLine(Calc(10, 20, (x, y) => x * y));

int Calc(int a, int b, Operation oper)
{
    return oper(a, b);
}

Random random = new();

int[] array = new int[10];
for (int i = 0; i < array.Length; i++)
    array[i] = random.Next() % 100;
foreach(int item in array)
    Console.Write($"{item} ");
Console.WriteLine();

int sumEven = SumItems(array, (i) => i % 2 == 0);
Console.WriteLine($"Sum even = {sumEven}");
int sum50 = SumItems(array, (i) => i > 50);
Console.WriteLine($"Sum items more 50 = {sum50}");


var operation = GetOperation('$');
Console.WriteLine($"Operation = {operation?.Invoke(20, 30)}");


int SumItems(int[] array, MyPredicat predicat)
{
    int sum = 0;
    foreach (var item in array)
        if (predicat(item))
            sum += item;
    return sum;
}

Operation? GetOperation(char sign)
{
    switch(sign)
    {
        case '+': return (x, y) => x + y;
        case '*': return (x, y) => x * y;
        case '-': return (x, y) => x - y;
        default:
            return null;
    }
}



delegate bool MyPredicat(int item);
delegate int Operation(int a, int b);
delegate void WriteConsole(string message);