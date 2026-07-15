
    MathAssignment math = new MathAssignment(
        "Austin Budd", "Circuit Analysis", "3.5", "12-18, 25");
    Console.WriteLine(math.GetSummary());
    Console.WriteLine(math.GetHomeworkList());

    Console.WriteLine();

    WritingAssignment writing = new WritingAssignment(
        "Austin Budd", "Power Electronics",
        "Efficiency Improvements in Buck Converters");
    Console.WriteLine(writing.GetSummary());
    Console.WriteLine(writing.GetWritingInformation());
