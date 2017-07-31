//This is technically a pseudocode attempt, I've never tried to compile this. It was created as an Over-the-Top response to the challenge.

public static void main()
{
	const int FizzModuloValue = 3;
	const int BuzzModuloValue = 3;

	FizzBuzzConfigClass fbcc = new FizzBuzzConfigClass("Fizz",FizzModuloValue, "Buzz", BuzzModuloValue);
	FizzBuzz(fbcc);
	
}

public class FizzBuzzConfigClass()
{
	public string FirstModuloStringValue;
	public string SecondModuloStringValue;
	public int FirstModuloValue;
	public int SecondModuloValue;
	
	public sub new(string FirstString, int FirstVal, string SecondString, int SecondVal) {
		this.FirstModuloStringValue = FirstString;
		this.SecondModuloStringValue = SecondString;
		this.FirstModuloValue = FirstVal;
		this.SecondModuloValue = SecondVal;
	}

}

public static void FizzBuzz(FizzBuzzConfigClass Conf) {
	for(int i = 1; i < 101; i++)
	{
		string s = "";
		s = StringComparisonByModulo(Conf.FirstModuloStringValue, Conf.FirstModuloValue, i)
		s = StringComparisonByModulo(Conf.SecondModuloStringValue, Conf.SecondModuloValue, i)
		s = (s = "") ? s : i.toString();
		console.WriteLine("s");
	}
}

public static void StringComparisonByModulo(string output, int comparison, int test) {
	return (test % number) == 0 ? output : "";
}
