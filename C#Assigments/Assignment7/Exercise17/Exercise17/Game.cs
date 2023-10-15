using System;


namespace Exercise17
{
    class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }
    public class Game
    {
        private int numberOfPlays;

        public Game()
        {
            numberOfPlays = 0;
        }
        public void Play()
        {

            try
            {
                numberOfPlays++;
                if (numberOfPlays > 5)
                {
                    throw new Exception("Warning !! Your have played this game 5 times...");

                }

                while (true)
                {
                    Console.WriteLine("Enter any number from 1-5:");
                    try
                    {
                        int choice = int.Parse(Console.ReadLine());

                        if (choice < 1 || choice > 5)
                        {
                            throw new Exception("Invalid input, please enter again:");

                        }


                        switch (choice)
                        {
                            case 1:
                                evenNumber();
                                break;
                            case 2:
                                oddNumber();
                                break;
                            case 3:
                                primeNumber();
                                break;
                            case 4:
                                negativeNumber();
                                break;
                            case 5:
                                zeroMethod();
                                break;
                            case 0:
                                Environment.Exit(0);
                                break;
                        }
                        Console.WriteLine();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                    finally
                    {
                        Play();
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void evenNumber()
        {
            try
            {
                Console.WriteLine("Enter even number");
                int num = int.Parse(Console.ReadLine());

                if (num % 2 != 0)
                {
                    throw new Exception("Invalid input, please enter even number");
                }
                else
                {
                    Console.WriteLine("Success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void oddNumber()
        {
            try
            {
                Console.WriteLine("Enter odd number");
                int num = int.Parse(Console.ReadLine());

                if (num % 2 == 0)
                {
                    throw new Exception("Invalid input, please enter odd number");
                }
                else
                {
                    Console.WriteLine("Success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void negativeNumber()
        {
            Console.WriteLine("Enter Negative number");
            int num = int.Parse(Console.ReadLine());

            try
            {
                if (num >= 0)
                {
                    throw new Exception("Invalid input, please enter Negative number only:");
                }
                else
                {
                    Console.WriteLine("Success!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void zeroMethod()
        {
            Console.WriteLine("Enter zero");
            int num = int.Parse(Console.ReadLine());

            try
            {
                if (num != 0)
                {
                    throw new Exception("Invalid input, please enter zero only:");
                }
                else
                {
                    Console.WriteLine("Success!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void primeNumber()
        {
            Console.WriteLine("Enter Prime Number");
            int num = int.Parse(Console.ReadLine());

            try
            {
                if (num <= 1) throw new Exception("Invalid input,Please enter Again!");

                for (int j = 2; j <= num/2; j++)
                {
                    if (num % j == 0)
                    {
                        throw new Exception("Invalid input,Please enter again!");
                    }
                    
                }

                Console.WriteLine("Success!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    
}
