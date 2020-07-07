using System;

namespace task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var validatorBuilder = Validator<String>.CreateValidator();
            validatorBuilder.Add(x=> x.Length > 5);
            validatorBuilder.Add(x => x[3].Equals('F'));

            Validator<String> validator;
            try
            {
                validator = validatorBuilder.Get();
            }
            catch (ZeroPredicateException e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            string str = "qwFty";
            try
            {
                validator.Fit(str);
            }
            catch (FalsePredicateException e)
            {
                Console.WriteLine(e);
            }
            
            var intValidatorBuilder = Validator<int>.CreateValidator();
            intValidatorBuilder.Add(x=> x > 5);
            intValidatorBuilder.Add(x => x != 7);

            Validator<int> intValidator;
            try
            {
                intValidator = intValidatorBuilder.Get();
            }
            catch (ZeroPredicateException e)
            {
                Console.WriteLine(e);
                throw;
            }

            int num1 = 9;
            int num2 = 7;
            try
            {
                intValidator.Fit(num1);
                intValidator.Fit(num2);
            }
            catch (FalsePredicateException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}