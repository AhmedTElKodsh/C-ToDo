using System.Text.RegularExpressions;

string select;
var todos = new List<string>();

InitialCheck(todos);

void InitialCheck(List<string> todos)
{
    do
    {
        Console.WriteLine("Hello!\r\n What do you want to do?\r\n[S]ee all TODOs\r\n[A]dd a TODO\r\n[R]emove a TODO\r\n[E]xit\r\n");
        select = Console.ReadLine().ToLower();
        if (string.IsNullOrEmpty(select) || !new List<string> { "s", "a", "r", "e" }.Contains(select))
        {
            Console.WriteLine("Invalid option\n");
        }
        if (select == "e") break;

    }
    while (string.IsNullOrEmpty(select) || !new List<string> { "s", "a", "r", "e" }.Contains(select));

    if (select == "e") Environment.Exit(0);

    switch (select)
    {
        case "s":
            ReadTodos(todos);
            break;
        case "a":
            AddTodo(todos);
            break;
        case "r":
            RemoveTodo(todos);
            break;
        default:
            Console.WriteLine("Incorrect input");
            break;
    }

}


void ReadTodos(List<string> todos)
{
    if (todos.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.\n");
        InitialCheck(todos);
    }
    else
    {
        for (int i = 1; i <= todos.Count; i++)
        {
            Console.WriteLine($"{i}- {todos[i - 1]}");
        }
        Console.WriteLine("What do you want to do?\n");
        InitialCheck(todos);
    }
}



void AddTodo(List<string> todos)
{
    string todo;
    do
    {
        Console.WriteLine("\nEnter a unique, non-empty TODO description:");
        todo = Console.ReadLine();
        if (string.IsNullOrEmpty(todo))
        {
            Console.WriteLine("Please enter a non-empty string");
            Console.WriteLine("Enter a unique, non-empty TODO description:\n");
            todo = Console.ReadLine();
        }
        else if (todos.Contains(todo))
        {
            Console.WriteLine("The description must be unique.\n");
        }
        else
        {
            todos.Add(todo);
            Console.WriteLine("TODO successfully added: " + todo + "\n");
            break;
        }

    }
    while (!string.IsNullOrEmpty(todo) || !todos.Contains(todo));

    InitialCheck(todos);
}

void RemoveTodo(List<string> todos)
{
    Console.WriteLine("\nSelect the index of the TODO you want to remove:");
    for (int i = 1; i <= todos.Count; i++)
    {
        Console.WriteLine($"{i}- {todos[i - 1]}");
    }
    var userInput = Console.ReadLine();

    int removeIndex;
    var isValid = int.TryParse(userInput, out removeIndex);

    if (!isValid)
    {
        Console.WriteLine("Invalid input. Please enter a valid number.\n");
    }
    else if (string.IsNullOrEmpty(userInput))
    {
        Console.WriteLine("Selected index cannot be empty.\n");
    }
    else if (Regex.IsMatch(userInput, $"[^0-{todos.Count}]"))
    {
        Console.WriteLine("The given index is not valid.\n");
    }
    else
    {
        if (todos.Count == 0)
        {
            Console.WriteLine("There are no Todos.\n");
        }
        else
        {
            Console.WriteLine("TODO removed: " + todos[removeIndex] + "\n");
            todos.RemoveAt(removeIndex - 1);
        }
    }
    InitialCheck(todos);
}