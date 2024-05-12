using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

string jsonStr = await File.ReadAllTextAsync("data.json");
//Console.WriteLine(jsonStr);

var model = JsonConvert.DeserializeObject<MainDto>(jsonStr);

foreach (var question in model.questions)
{
    Console.WriteLine(question.questionNo);
}

Console.WriteLine("To Number: " + ToNumber("၁၀"));

Console.ReadLine();


static int ToNumber(string num)
{
    num = num.Replace("၁", "1");
    num = num.Replace("၂", "2");
    num = num.Replace("၃", "3");
    num = num.Replace("၄", "4");
    num = num.Replace("၅", "5");
    num = num.Replace("၆", "6");
    num = num.Replace("၇", "7");
    num = num.Replace("၈", "8");
    num = num.Replace("၉", "9");
    num = num.Replace("၀", "0");

    return Int32.Parse(num);
}

// Copy the contents of json file
// Edit => Paste Special => Paste JSON as Classes
public class MainDto
{
    public Question[] questions { get; set; }
    public Answer[] answers { get; set; }
    public string[] numberList { get; set; }
}

public class Question
{
    public int questionNo { get; set; }
    public string questionName { get; set; }
}

public class Answer
{
    public int questionNo { get; set; }
    public int answerNo { get; set; }
    public string answerResult { get; set; }
}
