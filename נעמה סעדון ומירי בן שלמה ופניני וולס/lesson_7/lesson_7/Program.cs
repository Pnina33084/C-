// See https://aka.ms/new-console-template for more information
using System.Xml.Linq;


//exe1:
Console.WriteLine("exe1:");
XDocument doc = XDocument.Load("Xml.xml");
doc.Root.Descendants("seller").Where(c => c.Parent.Element("adress").Value == "tel aviv")
.Select(c => new
{
   seller = c.Value
}).ToList().ForEach(c => Console.WriteLine(c));

exe2:
Console.WriteLine("exe2:");
doc.Root.Descendants("item").Where(o => o.Element("price").Value == "100")
    .Select(o => new
    {
        name = o.Element("name").Value,
        price = o.Element("price").Value
    }).ToList().ForEach(o => Console.WriteLine(o));


//exe3:
Console.WriteLine("exe3:");
doc.Root.Elements("shop")
                    .Select(c => new
                    {
                        Name = c.Element("name").Value,
                        adress = c.Element("adress").Value
                    }
                            ).ToList().ForEach(c => Console.WriteLine(c));

Console.WriteLine("exe4:");
doc.Root.Descendants("item").Where(o => o.Element("name").Value == "skirt")
    .Select(o => new
    {
        name = o.Element("category").Value,
        price = o.Element("price").Value
    }).ToList().ForEach(o => Console.WriteLine(o));



XElement newItem = new XElement("item",
    new XElement("name", "new item"),
    new XElement("price", "150"),
    new XElement("category", "accessories")
);

XElement parentElement = doc.Root.Elements("shop").First();


parentElement.Element("items").Add(newItem);

doc.Save("Xml.xml");

















