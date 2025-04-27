// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Xml.Serialization;

public class Program {
    public class Osoba {
       public string Imie { get; set; }
       public string Nazwisko { get; set; }
       public int Wiek { get; set; }
       public DateTime DataUrodzenia { get; set; }
    }
    public class Student : Osoba {
        public string NumerIndeksu { get; set; }
        public string NumerGrupy { get; set; }
    }

    static void Main() {
        var osoby = new List<Osoba>{
            new Osoba{Imie = "Jan", Nazwisko = "Kowalski", Wiek = 20, DataUrodzenia = new DateTime(2003, 5, 1)},
            new Osoba{Imie = "Anna", Nazwisko = "Nowak", Wiek = 22, DataUrodzenia = new DateTime(2001, 3, 15)},
            new Osoba{Imie = "Piotr", Nazwisko = "Zielinski", Wiek = 19, DataUrodzenia = new DateTime(2004, 7, 10)},
            new Osoba{Imie = "Katarzyna", Nazwisko = "Wojcik", Wiek = 21, DataUrodzenia = new DateTime(2002, 11, 20)},
        };    
        var studenci = new List<Student> {
            new Student{Imie = "Marek", Nazwisko = "Kowal", Wiek = 23, DataUrodzenia = new DateTime(2000, 8, 5), NumerIndeksu = "123456", NumerGrupy = "A1"},
            new Student{Imie = "Ewa", Nazwisko = "Nowicka", Wiek = 24, DataUrodzenia = new DateTime(1999, 12, 30), NumerIndeksu = "654321", NumerGrupy = "B2"},
            new Student{Imie = "Tomasz", Nazwisko = "Kaczmarek", Wiek = 22, DataUrodzenia = new DateTime(2001, 4, 25), NumerIndeksu = "789012", NumerGrupy = "C3"},
            new Student{Imie = "Krystyna", Nazwisko = "Witkowska", Wiek = 20, DataUrodzenia = new DateTime(2003, 6, 15), NumerIndeksu = "345678", NumerGrupy = "D4"},
        };
        var serializer = new XmlSerializer(typeof(List<Osoba>));
        using (TextWriter writer = new StreamWriter("osoby.xml")) {
            serializer.Serialize(writer, osoby);
        }
        XmlSerializer serializer2 = new XmlSerializer(typeof(List<Student>));
        using (TextWriter writer = new StreamWriter("studenci.xml")) {
            serializer2.Serialize(writer, studenci);
        }
        using (TextWriter writer = new StreamWriter("osoby.json")) {
            string json = JsonSerializer.Serialize(osoby, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
            writer.Write(json);
        }
        using (TextWriter writer = new StreamWriter("studenci.json")) {
            string json = JsonSerializer.Serialize(studenci, new JsonSerializerOptions { WriteIndented = true });
            writer.WriteLine(json);
        }
        using (TextReader reader = new StreamReader("osoby.xml")) {
            try {
                Console.WriteLine("Deserializacja osób z pliku XML:");
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Osoba>));
                List<Osoba> osobyDeserialized = (List<Osoba>)deserializer.Deserialize(reader);
                foreach (var osoba in osobyDeserialized) {
                    Console.WriteLine($"Imie: {osoba.Imie}, Nazwisko: {osoba.Nazwisko}, Wiek: {osoba.Wiek}");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Wystąpił błąd podczas deserializacji: {ex.Message}");
            }
        }
        using (TextReader reader = new StreamReader("studenci.xml")) {
            try {
                Console.WriteLine("Deserializacja studentów z pliku XML:"); 
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Student>));
                List<Student> studenciDeserialized = (List<Student>)deserializer.Deserialize(reader);
                foreach (var student in studenciDeserialized) {
                    Console.WriteLine($"Imie: {student.Imie}, Nazwisko: {student.Nazwisko}, Wiek: {student.Wiek}, NumerIndeksu: {student.NumerIndeksu}, NumerGrupy: {student.NumerGrupy}");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Wystąpił błąd podczas deserializacji: {ex.Message}");
            }
        }
        using (TextReader reader = new StreamReader("osoby.json")) {
            try {
                Console.WriteLine("Deserializacja osób z pliku JSON:");
                string json = reader.ReadToEnd();
                List<Osoba> osobyDeserialized = JsonSerializer.Deserialize<List<Osoba>>(json);
                foreach (var osoba in osobyDeserialized) {
                    Console.WriteLine($"Imie: {osoba.Imie}, Nazwisko: {osoba.Nazwisko}, Wiek: {osoba.Wiek}");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Wystąpił błąd podczas deserializacji: {ex.Message}");
            }
        }
        using (TextReader reader = new StreamReader("studenci.json")) {
            try {
                Console.WriteLine("Deserializacja studentów z pliku JSON:");
                string json = reader.ReadToEnd();
                List<Student> studenciDeserialized = JsonSerializer.Deserialize<List<Student>>(json);
                foreach (var student in studenciDeserialized) {
                    Console.WriteLine($"Imie: {student.Imie}, Nazwisko: {student.Nazwisko}, Wiek: {student.Wiek}, NumerIndeksu: {student.NumerIndeksu}, NumerGrupy: {student.NumerGrupy}");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Wystąpił błąd podczas deserializacji: {ex.Message}");
            }
        }
    }
}