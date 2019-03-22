# UsingBlockTest
This concept proof console program is created to test the scope of the variables and how .Net is disposing them when a using() block is involved.

Two dummy object instances having a field of type FileStream are created to hold the content of two different files. One of the files is read into memory at the using() block and the other one is read into memory inside the using() block.

```csharp
            Dummy d1 = new Dummy();
            Dummy d2 = new Dummy();

            string path1 = @"TextFile1.txt";
            string path2 = @"TextFile2.txt";

            using (var s1 = new FileStream(path1, FileMode.Append))
            {
                d1.stream = s1;

                var s2 = new FileStream(path2, FileMode.Append);
                d2.stream = s2;
            }

            try
            {
                Console.WriteLine("d1 length:");
                Console.WriteLine(d1.stream.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("d2 length:");
                Console.WriteLine(d2.stream.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
```

The above code gives the following result:
```
d1 length:
Cannot access a closed file.
d2 length:
49
Press enter to exit.
```
