using Mod02_AdvProgramming.Data.Properties;

namespace Mod02_AdvProgramming.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public static class SampleData
    {
        public static IEnumerable<Customer> LoadCustomersFromMemory()
        {
            List<Customer> custs = new List<Customer>();
            Customer c;

            c = new Customer();
            c.CustomerID = "ALFKI";
            c.CompanyName = "Alfreds Futterkiste";
            c.Name = "Maria Anders";
            c.ContactTitle = "Sales Representative";
            c.Address = "Obere Str. 57";
            c.City = "Berlin";
            c.PostalCode = "12209";
            c.Country = "Germany";
            c.Phone = "030-0074321";
            c.Fax = "030-0076545";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "ANATR";
            c.CompanyName = "Ana Trujillo Emparedados y helados";
            c.Name = "Ana Trujillo";
            c.ContactTitle = "Owner";
            c.Address = "Avda. de la Constitución 2222";
            c.City = "México D.F.";
            c.PostalCode = "05021";
            c.Country = "Mexico";
            c.Phone = "(5) 555-4729";
            c.Fax = "(5) 555-3745";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "ANTON";
            c.CompanyName = "Antonio Moreno Taquería";
            c.Name = "Antonio Moreno";
            c.ContactTitle = "Owner";
            c.Address = "Mataderos  2312";
            c.City = "México D.F.";
            c.PostalCode = "05023";
            c.Country = "Mexico";
            c.Phone = "(5) 555-3932";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "AROUT";
            c.CompanyName = "Around the Horn";
            c.Name = "Thomas Hardy";
            c.ContactTitle = "Sales Representative";
            c.Address = "120 Hanover Sq.";
            c.City = "London";
            c.PostalCode = "WA1 1DP";
            c.Country = "UK";
            c.Phone = "(171) 555-7788";
            c.Fax = "(171) 555-6750";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "BERGS";
            c.CompanyName = "Berglunds snabbköp";
            c.Name = "Christina Berglund";
            c.ContactTitle = "Order Administrator";
            c.Address = "Berguvsvägen  8";
            c.City = "Luleå";
            c.PostalCode = "S-958 22";
            c.Country = "Sweden";
            c.Phone = "0921-12 34 65";
            c.Fax = "0921-12 34 67";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "BLAUS";
            c.CompanyName = "Blauer See Delikatessen";
            c.Name = "Hanna Moos";
            c.ContactTitle = "Sales Representative";
            c.Address = "Forsterstr. 57";
            c.City = "Mannheim";
            c.PostalCode = "68306";
            c.Country = "Germany";
            c.Phone = "0621-08460";
            c.Fax = "0621-08924";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "BLONP";
            c.CompanyName = "Blondesddsl père et fils";
            c.Name = "Frédérique Citeaux";
            c.ContactTitle = "Marketing Manager";
            c.Address = "24, place Kléber";
            c.City = "Strasbourg";
            c.PostalCode = "67000";
            c.Country = "France";
            c.Phone = "88.60.15.31";
            c.Fax = "88.60.15.32";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "BOLID";
            c.CompanyName = "Bólido Comidas preparadas";
            c.Name = "Martín Sommer";
            c.ContactTitle = "Owner";
            c.Address = "C/ Araquil, 67";
            c.City = "Madrid";
            c.PostalCode = "28023";
            c.Country = "Spain";
            c.Phone = "(91) 555 22 82";
            c.Fax = "(91) 555 91 99";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "BONAP";
            c.CompanyName = "Bon app'";
            c.Name = "Laurence Lebihan";
            c.ContactTitle = "Owner";
            c.Address = "12, rue des Bouchers";
            c.City = "Marseille";
            c.PostalCode = "13008";
            c.Country = "France";
            c.Phone = "91.24.45.40";
            c.Fax = "91.24.45.41";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "BOTTM";
            c.CompanyName = "Bottom-Dollar Markets";
            c.Name = "Elizabeth Lincoln";
            c.ContactTitle = "Accounting Manager";
            c.Address = "23 Tsawassen Blvd.";
            c.City = "Tsawassen";
            c.Region = "BC";
            c.PostalCode = "T2F 8M4";
            c.Country = "Canada";
            c.Phone = "(604) 555-4729";
            c.Fax = "(604) 555-3745";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "BSBEV";
            c.CompanyName = "B's Beverages";
            c.Name = "Victoria Ashworth";
            c.ContactTitle = "Sales Representative";
            c.Address = "Fauntleroy Circus";
            c.City = "London";
            c.PostalCode = "EC2 5NT";
            c.Country = "UK";
            c.Phone = "(171) 555-1212";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "CACTU";
            c.CompanyName = "Cactus Comidas para llevar";
            c.Name = "Patricio Simpson";
            c.ContactTitle = "Sales Agent";
            c.Address = "Cerrito 333";
            c.City = "Buenos Aires";
            c.PostalCode = "1010";
            c.Country = "Argentina";
            c.Phone = "(1) 135-5555";
            c.Fax = "(1) 135-4892";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "CENTC";
            c.CompanyName = "Centro comercial Moctezuma";
            c.Name = "Francisco Chang";
            c.ContactTitle = "Marketing Manager";
            c.Address = "Sierras de Granada 9993";
            c.City = "México D.F.";
            c.PostalCode = "05022";
            c.Country = "Mexico";
            c.Phone = "(5) 555-3392";
            c.Fax = "(5) 555-7293";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "CHOPS";
            c.CompanyName = "Chop-suey Chinese";
            c.Name = "Yang Wang";
            c.ContactTitle = "Owner";
            c.Address = "Hauptstr. 29";
            c.City = "Bern";
            c.PostalCode = "3012";
            c.Country = "Switzerland";
            c.Phone = "0452-076545";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "COMMI";
            c.CompanyName = "Comércio Mineiro";
            c.Name = "Pedro Afonso";
            c.ContactTitle = "Sales Associate";
            c.Address = "Av. dos Lusíadas, 23";
            c.City = "Sao Paulo";
            c.Region = "SP";
            c.PostalCode = "05432-043";
            c.Country = "Brazil";
            c.Phone = "(11) 555-7647";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "CONSH";
            c.CompanyName = "Consolidated Holdings";
            c.Name = "Elizabeth Brown";
            c.ContactTitle = "Sales Representative";
            c.Address = "Berkeley Gardens 12  Brewery";
            c.City = "London";
            c.PostalCode = "WX1 6LT";
            c.Country = "UK";
            c.Phone = "(171) 555-2282";
            c.Fax = "(171) 555-9199";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "DRACD";
            c.CompanyName = "Drachenblut Delikatessen";
            c.Name = "Sven Ottlieb";
            c.ContactTitle = "Order Administrator";
            c.Address = "Walserweg 21";
            c.City = "Aachen";
            c.PostalCode = "52066";
            c.Country = "Germany";
            c.Phone = "0241-039123";
            c.Fax = "0241-059428";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "DUMON";
            c.CompanyName = "Du monde entier";
            c.Name = "Janine Labrune";
            c.ContactTitle = "Owner";
            c.Address = "67, rue des Cinquante Otages";
            c.City = "Nantes";
            c.PostalCode = "44000";
            c.Country = "France";
            c.Phone = "40.67.88.88";
            c.Fax = "40.67.89.89";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "EASTC";
            c.CompanyName = "Eastern Connection";
            c.Name = "Ann Devon";
            c.ContactTitle = "Sales Agent";
            c.Address = "35 King George";
            c.City = "London";
            c.PostalCode = "WX3 6FW";
            c.Country = "UK";
            c.Phone = "(171) 555-0297";
            c.Fax = "(171) 555-3373";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "ERNSH";
            c.CompanyName = "Ernst Handel";
            c.Name = "Roland Mendel";
            c.ContactTitle = "Sales Manager";
            c.Address = "Kirchgasse 6";
            c.City = "Graz";
            c.PostalCode = "8010";
            c.Country = "Austria";
            c.Phone = "7675-3425";
            c.Fax = "7675-3426";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "FAMIA";
            c.CompanyName = "Familia Arquibaldo";
            c.Name = "Aria Cruz";
            c.ContactTitle = "Marketing Assistant";
            c.Address = "Rua Orós, 92";
            c.City = "Sao Paulo";
            c.Region = "SP";
            c.PostalCode = "05442-030";
            c.Country = "Brazil";
            c.Phone = "(11) 555-9857";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "FISSA";
            c.CompanyName = "FISSA Fabrica Inter. Salchichas S.A.";
            c.Name = "Diego Roel";
            c.ContactTitle = "Accounting Manager";
            c.Address = "C/ Moralzarzal, 86";
            c.City = "Madrid";
            c.PostalCode = "28034";
            c.Country = "Spain";
            c.Phone = "(91) 555 94 44";
            c.Fax = "(91) 555 55 93";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "FOLIG";
            c.CompanyName = "Folies gourmandes";
            c.Name = "Martine Rancé";
            c.ContactTitle = "Assistant Sales Agent";
            c.Address = "184, chaussée de Tournai";
            c.City = "Lille";
            c.PostalCode = "59000";
            c.Country = "France";
            c.Phone = "20.16.10.16";
            c.Fax = "20.16.10.17";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "FOLKO";
            c.CompanyName = "Folk och fä HB";
            c.Name = "Maria Larsson";
            c.ContactTitle = "Owner";
            c.Address = "Åkergatan 24";
            c.City = "Bräcke";
            c.PostalCode = "S-844 67";
            c.Country = "Sweden";
            c.Phone = "0695-34 67 21";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "FRANK";
            c.CompanyName = "Frankenversand";
            c.Name = "Peter Franken";
            c.ContactTitle = "Marketing Manager";
            c.Address = "Berliner Platz 43";
            c.City = "München";
            c.PostalCode = "80805";
            c.Country = "Germany";
            c.Phone = "089-0877310";
            c.Fax = "089-0877451";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "FRANR";
            c.CompanyName = "France restauration";
            c.Name = "Carine Schmitt";
            c.ContactTitle = "Marketing Manager";
            c.Address = "54, rue Royale";
            c.City = "Nantes";
            c.PostalCode = "44000";
            c.Country = "France";
            c.Phone = "40.32.21.21";
            c.Fax = "40.32.21.20";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "FRANS";
            c.CompanyName = "Franchi S.p.A.";
            c.Name = "Paolo Accorti";
            c.ContactTitle = "Sales Representative";
            c.Address = "Via Monte Bianco 34";
            c.City = "Torino";
            c.PostalCode = "10100";
            c.Country = "Italy";
            c.Phone = "011-4988260";
            c.Fax = "011-4988261";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "FURIB";
            c.CompanyName = "Furia Bacalhau e Frutos do Mar";
            c.Name = "Lino Rodriguez";
            c.ContactTitle = "Sales Manager";
            c.Address = "Jardim das rosas n. 32";
            c.City = "Lisboa";
            c.PostalCode = "1675";
            c.Country = "Portugal";
            c.Phone = "(1) 354-2534";
            c.Fax = "(1) 354-2535";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "GALED";
            c.CompanyName = "Galería del gastrónomo";
            c.Name = "Eduardo Saavedra";
            c.ContactTitle = "Marketing Manager";
            c.Address = "Rambla de Cataluña, 23";
            c.City = "Barcelona";
            c.PostalCode = "08022";
            c.Country = "Spain";
            c.Phone = "(93) 203 4560";
            c.Fax = "(93) 203 4561";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "GODOS";
            c.CompanyName = "Godos Cocina Típica";
            c.Name = "José Pedro Freyre";
            c.ContactTitle = "Sales Manager";
            c.Address = "C/ Romero, 33";
            c.City = "Sevilla";
            c.PostalCode = "41101";
            c.Country = "Spain";
            c.Phone = "(95) 555 82 82";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "GOURL";
            c.CompanyName = "Gourmet Lanchonetes";
            c.Name = "André Fonseca";
            c.ContactTitle = "Sales Associate";
            c.Address = "Av. Brasil, 442";
            c.City = "Campinas";
            c.Region = "SP";
            c.PostalCode = "04876-786";
            c.Country = "Brazil";
            c.Phone = "(11) 555-9482";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "GREAL";
            c.CompanyName = "Great Lakes Food Market";
            c.Name = "Howard Snyder";
            c.ContactTitle = "Marketing Manager";
            c.Address = "2732 Baker Blvd.";
            c.City = "Eugene";
            c.Region = "OR";
            c.PostalCode = "97403";
            c.Country = "USA";
            c.Phone = "(503) 555-7555";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "GROSR";
            c.CompanyName = "GROSELLA-Restaurante";
            c.Name = "Manuel Pereira";
            c.ContactTitle = "Owner";
            c.Address = "5ª Ave. Los Palos Grandes";
            c.City = "Caracas";
            c.Region = "DF";
            c.PostalCode = "1081";
            c.Country = "Venezuela";
            c.Phone = "(2) 283-2951";
            c.Fax = "(2) 283-3397";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "HANAR";
            c.CompanyName = "Hanari Carnes";
            c.Name = "Mario Pontes";
            c.ContactTitle = "Accounting Manager";
            c.Address = "Rua do Paço, 67";
            c.City = "Rio de Janeiro";
            c.Region = "RJ";
            c.PostalCode = "05454-876";
            c.Country = "Brazil";
            c.Phone = "(21) 555-0091";
            c.Fax = "(21) 555-8765";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "HILAA";
            c.CompanyName = "HILARION-Abastos";
            c.Name = "Carlos Hernández";
            c.ContactTitle = "Sales Representative";
            c.Address = "Carrera 22 con Ave. Carlos Soublette #8-35";
            c.City = "San Cristóbal";
            c.Region = "Táchira";
            c.PostalCode = "5022";
            c.Country = "Venezuela";
            c.Phone = "(5) 555-1340";
            c.Fax = "(5) 555-1948";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "HUNGC";
            c.CompanyName = "Hungry Coyote Import Store";
            c.Name = "Yoshi Latimer";
            c.ContactTitle = "Sales Representative";
            c.Address = "City Center Plaza 516 Main St.";
            c.City = "Elgin";
            c.Region = "OR";
            c.PostalCode = "97827";
            c.Country = "USA";
            c.Phone = "(503) 555-6874";
            c.Fax = "(503) 555-2376";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "HUNGO";
            c.CompanyName = "Hungry Owl All-Night Grocers";
            c.Name = "Patricia McKenna";
            c.ContactTitle = "Sales Associate";
            c.Address = "8 Johnstown Road";
            c.City = "Cork";
            c.Region = "Co. Cork";
            c.Country = "Ireland";
            c.Phone = "2967 542";
            c.Fax = "2967 3333";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "ISLAT";
            c.CompanyName = "Island Trading";
            c.Name = "Helen Bennett";
            c.ContactTitle = "Marketing Manager";
            c.Address = "Garden House Crowther Way";
            c.City = "Cowes";
            c.Region = "Isle of Wight";
            c.PostalCode = "PO31 7PJ";
            c.Country = "UK";
            c.Phone = "(198) 555-8888";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "KOENE";
            c.CompanyName = "Königlich Essen";
            c.Name = "Philip Cramer";
            c.ContactTitle = "Sales Associate";
            c.Address = "Maubelstr. 90";
            c.City = "Brandenburg";
            c.PostalCode = "14776";
            c.Country = "Germany";
            c.Phone = "0555-09876";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "LACOR";
            c.CompanyName = "La corne d'abondance";
            c.Name = "Daniel Tonini";
            c.ContactTitle = "Sales Representative";
            c.Address = "67, avenue de l'Europe";
            c.City = "Versailles";
            c.PostalCode = "78000";
            c.Country = "France";
            c.Phone = "30.59.84.10";
            c.Fax = "30.59.85.11";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "LAMAI";
            c.CompanyName = "La maison d'Asie";
            c.Name = "Annette Roulet";
            c.ContactTitle = "Sales Manager";
            c.Address = "1 rue Alsace-Lorraine";
            c.City = "Toulouse";
            c.PostalCode = "31000";
            c.Country = "France";
            c.Phone = "61.77.61.10";
            c.Fax = "61.77.61.11";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "LAUGB";
            c.CompanyName = "Laughing Bacchus Wine Cellars";
            c.Name = "Yoshi Tannamuri";
            c.ContactTitle = "Marketing Assistant";
            c.Address = "1900 Oak St.";
            c.City = "Vancouver";
            c.Region = "BC";
            c.PostalCode = "V3F 2K1";
            c.Country = "Canada";
            c.Phone = "(604) 555-3392";
            c.Fax = "(604) 555-7293";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "LAZYK";
            c.CompanyName = "Lazy K Kountry Store";
            c.Name = "John Steel";
            c.ContactTitle = "Marketing Manager";
            c.Address = "12 Orchestra Terrace";
            c.City = "Walla Walla";
            c.Region = "WA";
            c.PostalCode = "99362";
            c.Country = "USA";
            c.Phone = "(509) 555-7969";
            c.Fax = "(509) 555-6221";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "LEHMS";
            c.CompanyName = "Lehmanns Marktstand";
            c.Name = "Renate Messner";
            c.ContactTitle = "Sales Representative";
            c.Address = "Magazinweg 7";
            c.City = "Frankfurt a.M.";
            c.PostalCode = "60528";
            c.Country = "Germany";
            c.Phone = "069-0245984";
            c.Fax = "069-0245874";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "LETSS";
            c.CompanyName = "Let's Stop N Shop";
            c.Name = "Jaime Yorres";
            c.ContactTitle = "Owner";
            c.Address = "87 Polk St. Suite 5";
            c.City = "San Francisco";
            c.Region = "CA";
            c.PostalCode = "94117";
            c.Country = "USA";
            c.Phone = "(415) 555-5938";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "LILAS";
            c.CompanyName = "LILA-Supermercado";
            c.Name = "Carlos González";
            c.ContactTitle = "Accounting Manager";
            c.Address = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo";
            c.City = "Barquisimeto";
            c.Region = "Lara";
            c.PostalCode = "3508";
            c.Country = "Venezuela";
            c.Phone = "(9) 331-6954";
            c.Fax = "(9) 331-7256";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "LINOD";
            c.CompanyName = "LINO-Delicateses";
            c.Name = "Felipe Izquierdo";
            c.ContactTitle = "Owner";
            c.Address = "Ave. 5 de Mayo Porlamar";
            c.City = "I. de Margarita";
            c.Region = "Nueva Esparta";
            c.PostalCode = "4980";
            c.Country = "Venezuela";
            c.Phone = "(8) 34-56-12";
            c.Fax = "(8) 34-93-93";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "LONEP";
            c.CompanyName = "Lonesome Pine Restaurant";
            c.Name = "Fran Wilson";
            c.ContactTitle = "Sales Manager";
            c.Address = "89 Chiaroscuro Rd.";
            c.City = "Portland";
            c.Region = "OR";
            c.PostalCode = "97219";
            c.Country = "USA";
            c.Phone = "(503) 555-9573";
            c.Fax = "(503) 555-9646";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "MAGAA";
            c.CompanyName = "Magazzini Alimentari Riuniti";
            c.Name = "Giovanni Rovelli";
            c.ContactTitle = "Marketing Manager";
            c.Address = "Via Ludovico il Moro 22";
            c.City = "Bergamo";
            c.PostalCode = "24100";
            c.Country = "Italy";
            c.Phone = "035-640230";
            c.Fax = "035-640231";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "MAISD";
            c.CompanyName = "Maison Dewey";
            c.Name = "Catherine Dewey";
            c.ContactTitle = "Sales Agent";
            c.Address = "Rue Joseph-Bens 532";
            c.City = "Bruxelles";
            c.PostalCode = "B-1180";
            c.Country = "Belgium";
            c.Phone = "(02) 201 24 67";
            c.Fax = "(02) 201 24 68";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "MEREP";
            c.CompanyName = "Mère Paillarde";
            c.Name = "Jean Fresnière";
            c.ContactTitle = "Marketing Assistant";
            c.Address = "43 rue St. Laurent";
            c.City = "Montréal";
            c.Region = "Québec";
            c.PostalCode = "H1J 1C3";
            c.Country = "Canada";
            c.Phone = "(514) 555-8054";
            c.Fax = "(514) 555-8055";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "MORGK";
            c.CompanyName = "Morgenstern Gesundkost";
            c.Name = "Alexander Feuer";
            c.ContactTitle = "Marketing Assistant";
            c.Address = "Heerstr. 22";
            c.City = "Leipzig";
            c.PostalCode = "04179";
            c.Country = "Germany";
            c.Phone = "0342-023176";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "NORTS";
            c.CompanyName = "North/South";
            c.Name = "Simon Crowther";
            c.ContactTitle = "Sales Associate";
            c.Address = "South House 300 Queensbridge";
            c.City = "London";
            c.PostalCode = "SW7 1RZ";
            c.Country = "UK";
            c.Phone = "(171) 555-7733";
            c.Fax = "(171) 555-2530";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "OCEAN";
            c.CompanyName = "Océano Atlántico Ltda.";
            c.Name = "Yvonne Moncada";
            c.ContactTitle = "Sales Agent";
            c.Address = "Ing. Gustavo Moncada 8585 Piso 20-A";
            c.City = "Buenos Aires";
            c.PostalCode = "1010";
            c.Country = "Argentina";
            c.Phone = "(1) 135-5333";
            c.Fax = "(1) 135-5535";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "OLDWO";
            c.CompanyName = "Old World Delicatessen";
            c.Name = "Rene Phillips";
            c.ContactTitle = "Sales Representative";
            c.Address = "2743 Bering St.";
            c.City = "Anchorage";
            c.Region = "AK";
            c.PostalCode = "99508";
            c.Country = "USA";
            c.Phone = "(907) 555-7584";
            c.Fax = "(907) 555-2880";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "OTTIK";
            c.CompanyName = "Ottilies Käseladen";
            c.Name = "Henriette Pfalzheim";
            c.ContactTitle = "Owner";
            c.Address = "Mehrheimerstr. 369";
            c.City = "Köln";
            c.PostalCode = "50739";
            c.Country = "Germany";
            c.Phone = "0221-0644327";
            c.Fax = "0221-0765721";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "PARIS";
            c.CompanyName = "Paris spécialités";
            c.Name = "Marie Bertrand";
            c.ContactTitle = "Owner";
            c.Address = "265, boulevard Charonne";
            c.City = "Paris";
            c.PostalCode = "75012";
            c.Country = "France";
            c.Phone = "(1) 42.34.22.66";
            c.Fax = "(1) 42.34.22.77";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "PERIC";
            c.CompanyName = "Pericles Comidas clásicas";
            c.Name = "Guillermo Fernández";
            c.ContactTitle = "Sales Representative";
            c.Address = "Calle Dr. Jorge Cash 321";
            c.City = "México D.F.";
            c.PostalCode = "05033";
            c.Country = "Mexico";
            c.Phone = "(5) 552-3745";
            c.Fax = "(5) 545-3745";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "PICCO";
            c.CompanyName = "Piccolo und mehr";
            c.Name = "Georg Pipps";
            c.ContactTitle = "Sales Manager";
            c.Address = "Geislweg 14";
            c.City = "Salzburg";
            c.PostalCode = "5020";
            c.Country = "Austria";
            c.Phone = "6562-9722";
            c.Fax = "6562-9723";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "PRINI";
            c.CompanyName = "Princesa Isabel Vinhos";
            c.Name = "Isabel de Castro";
            c.ContactTitle = "Sales Representative";
            c.Address = "Estrada da saúde n. 58";
            c.City = "Lisboa";
            c.PostalCode = "1756";
            c.Country = "Portugal";
            c.Phone = "(1) 356-5634";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "PTC2 ";
            c.CompanyName = "C3";
            c.City = "C1";
            c.Country = "PT";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "QUEDE";
            c.CompanyName = "Que Delícia";
            c.Name = "Bernardo Batista";
            c.ContactTitle = "Accounting Manager";
            c.Address = "Rua da Panificadora, 12";
            c.City = "Rio de Janeiro";
            c.Region = "RJ";
            c.PostalCode = "02389-673";
            c.Country = "Brazil";
            c.Phone = "(21) 555-4252";
            c.Fax = "(21) 555-4545";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "QUEEN";
            c.CompanyName = "Queen Cozinha";
            c.Name = "Lúcia Carvalho";
            c.ContactTitle = "Marketing Assistant";
            c.Address = "Alameda dos Canàrios, 891";
            c.City = "Sao Paulo";
            c.Region = "SP";
            c.PostalCode = "05487-020";
            c.Country = "Brazil";
            c.Phone = "(11) 555-1189";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "QUICK";
            c.CompanyName = "QUICK-Stop";
            c.Name = "Horst Kloss";
            c.ContactTitle = "Accounting Manager";
            c.Address = "Taucherstraße 10";
            c.City = "Cunewalde";
            c.PostalCode = "01307";
            c.Country = "Germany";
            c.Phone = "0372-035188";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "RANCH";
            c.CompanyName = "Rancho grande";
            c.Name = "Sergio Gutiérrez";
            c.ContactTitle = "Sales Representative";
            c.Address = "Av. del Libertador 900";
            c.City = "Buenos Aires";
            c.PostalCode = "1010";
            c.Country = "Argentina";
            c.Phone = "(1) 123-5555";
            c.Fax = "(1) 123-5556";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "RATTC";
            c.CompanyName = "Rattlesnake Canyon Grocery";
            c.Name = "Paula Wilson";
            c.ContactTitle = "Assistant Sales Representative";
            c.Address = "2817 Milton Dr.";
            c.City = "Albuquerque";
            c.Region = "NM";
            c.PostalCode = "87110";
            c.Country = "USA";
            c.Phone = "(505) 555-5939";
            c.Fax = "(505) 555-3620";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "REGGC";
            c.CompanyName = "Reggiani Caseifici";
            c.Name = "Maurizio Moroni";
            c.ContactTitle = "Sales Associate";
            c.Address = "Strada Provinciale 124";
            c.City = "Reggio Emilia";
            c.PostalCode = "42100";
            c.Country = "Italy";
            c.Phone = "0522-556721";
            c.Fax = "0522-556722";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "RICAR";
            c.CompanyName = "Ricardo Adocicados";
            c.Name = "Janete Limeira";
            c.ContactTitle = "Assistant Sales Agent";
            c.Address = "Av. Copacabana, 267";
            c.City = "Rio de Janeiro";
            c.Region = "RJ";
            c.PostalCode = "02389-890";
            c.Country = "Brazil";
            c.Phone = "(21) 555-3412";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "RICSU";
            c.CompanyName = "Richter Supermarkt";
            c.Name = "Michael Holz";
            c.ContactTitle = "Sales Manager";
            c.Address = "Grenzacherweg 237";
            c.City = "Genève";
            c.PostalCode = "1203";
            c.Country = "Switzerland";
            c.Phone = "0897-034214";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "ROMEY";
            c.CompanyName = "Romero y tomillo";
            c.Name = "Alejandra Camino";
            c.ContactTitle = "Accounting Manager";
            c.Address = "Gran Vía, 1";
            c.City = "Madrid";
            c.PostalCode = "28001";
            c.Country = "Spain";
            c.Phone = "(91) 745 6200";
            c.Fax = "(91) 745 6210";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "SANTG";
            c.CompanyName = "Santé Gourmet";
            c.Name = "Jonas Bergulfsen";
            c.ContactTitle = "Owner";
            c.Address = "Erling Skakkes gate 78";
            c.City = "Stavern";
            c.PostalCode = "4110";
            c.Country = "Norway";
            c.Phone = "07-98 92 35";
            c.Fax = "07-98 92 47";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "SAVEA";
            c.CompanyName = "Save-a-lot Markets";
            c.Name = "Jose Pavarotti";
            c.ContactTitle = "Sales Representative";
            c.Address = "187 Suffolk Ln.";
            c.City = "Boise";
            c.Region = "ID";
            c.PostalCode = "83720";
            c.Country = "USA";
            c.Phone = "(208) 555-8097";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "SEVES";
            c.CompanyName = "Seven Seas Imports";
            c.Name = "Hari Kumar";
            c.ContactTitle = "Sales Manager";
            c.Address = "90 Wadhurst Rd.";
            c.City = "London";
            c.PostalCode = "OX15 4NB";
            c.Country = "UK";
            c.Phone = "(171) 555-1717";
            c.Fax = "(171) 555-5646";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "SIMOB";
            c.CompanyName = "Simons bistro";
            c.Name = "Jytte Petersen";
            c.ContactTitle = "Owner";
            c.Address = "Vinbæltet 34";
            c.City = "Kobenhavn";
            c.PostalCode = "1734";
            c.Country = "Denmark";
            c.Phone = "31 12 34 56";
            c.Fax = "31 13 35 57";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "SPECD";
            c.CompanyName = "Spécialités du monde";
            c.Name = "Dominique Perrier";
            c.ContactTitle = "Marketing Manager";
            c.Address = "25, rue Lauriston";
            c.City = "Paris";
            c.PostalCode = "75016";
            c.Country = "France";
            c.Phone = "(1) 47.55.60.10";
            c.Fax = "(1) 47.55.60.20";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "SPLIR";
            c.CompanyName = "Split Rail Beer & Ale";
            c.Name = "Art Braunschweiger";
            c.ContactTitle = "Sales Manager";
            c.Address = "P.O. Box 555";
            c.City = "Lander";
            c.Region = "WY";
            c.PostalCode = "82520";
            c.Country = "USA";
            c.Phone = "(307) 555-4680";
            c.Fax = "(307) 555-6525";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "SUPRD";
            c.CompanyName = "Suprêmes délices";
            c.Name = "Pascale Cartrain";
            c.ContactTitle = "Accounting Manager";
            c.Address = "Boulevard Tirou, 255";
            c.City = "Charleroi";
            c.PostalCode = "B-6000";
            c.Country = "Belgium";
            c.Phone = "(071) 23 67 22 20";
            c.Fax = "(071) 23 67 22 21";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "THEBI";
            c.CompanyName = "The Big Cheese";
            c.Name = "Liz Nixon";
            c.ContactTitle = "Marketing Manager";
            c.Address = "89 Jefferson Way Suite 2";
            c.City = "Portland";
            c.Region = "OR";
            c.PostalCode = "97201";
            c.Country = "USA";
            c.Phone = "(503) 555-3612";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "THECR";
            c.CompanyName = "The Cracker Box";
            c.Name = "Liu Wong";
            c.ContactTitle = "Marketing Assistant";
            c.Address = "55 Grizzly Peak Rd.";
            c.City = "Butte";
            c.Region = "MT";
            c.PostalCode = "59801";
            c.Country = "USA";
            c.Phone = "(406) 555-5834";
            c.Fax = "(406) 555-8083";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "TOMSP";
            c.CompanyName = "Toms Spezialitäten";
            c.Name = "Karin Josephs";
            c.ContactTitle = "Marketing Manager";
            c.Address = "Luisenstr. 48";
            c.City = "Münster";
            c.PostalCode = "44087";
            c.Country = "Germany";
            c.Phone = "0251-031259";
            c.Fax = "0251-035695";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "TORTU";
            c.CompanyName = "Tortuga Restaurante";
            c.Name = "Miguel Angel Paolino";
            c.ContactTitle = "Owner";
            c.Address = "Avda. Azteca 123";
            c.City = "México D.F.";
            c.PostalCode = "05033";
            c.Country = "Mexico";
            c.Phone = "(5) 555-2933";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "TRADH";
            c.CompanyName = "Tradição Hipermercados";
            c.Name = "Anabela Domingues";
            c.ContactTitle = "Sales Representative";
            c.Address = "Av. Inês de Castro, 414";
            c.City = "Sao Paulo";
            c.Region = "SP";
            c.PostalCode = "05634-030";
            c.Country = "Brazil";
            c.Phone = "(11) 555-2167";
            c.Fax = "(11) 555-2168";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "TRAIH";
            c.CompanyName = "Trail's Head Gourmet Provisioners";
            c.Name = "Helvetius Nagy";
            c.ContactTitle = "Sales Associate";
            c.Address = "722 DaVinci Blvd.";
            c.City = "Kirkland";
            c.Region = "WA";
            c.PostalCode = "98034";
            c.Country = "USA";
            c.Phone = "(206) 555-8257";
            c.Fax = "(206) 555-2174";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "VAFFE";
            c.CompanyName = "Vaffeljernet";
            c.Name = "Palle Ibsen";
            c.ContactTitle = "Sales Manager";
            c.Address = "Smagsloget 45";
            c.City = "Århus";
            c.PostalCode = "8200";
            c.Country = "Denmark";
            c.Phone = "86 21 32 43";
            c.Fax = "86 22 33 44";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "VICTE";
            c.CompanyName = "Victuailles en stock";
            c.Name = "Mary Saveley";
            c.ContactTitle = "Sales Agent";
            c.Address = "2, rue du Commerce";
            c.City = "Lyon";
            c.PostalCode = "69004";
            c.Country = "France";
            c.Phone = "78.32.54.86";
            c.Fax = "78.32.54.87";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "VINET";
            c.CompanyName = "Vins et alcools Chevalier";
            c.Name = "Paul Henriot";
            c.ContactTitle = "Accounting Manager";
            c.Address = "59 rue de l'Abbaye";
            c.City = "Reims";
            c.PostalCode = "51100";
            c.Country = "France";
            c.Phone = "26.47.15.10";
            c.Fax = "26.47.15.11";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "WANDK";
            c.CompanyName = "Die Wandernde Kuh";
            c.Name = "Rita Müller";
            c.ContactTitle = "Sales Representative";
            c.Address = "Adenauerallee 900";
            c.City = "Stuttgart";
            c.PostalCode = "70563";
            c.Country = "Germany";
            c.Phone = "0711-020361";
            c.Fax = "0711-035428";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "WARTH";
            c.CompanyName = "Wartian Herkku";
            c.Name = "Pirkko Koskitalo";
            c.ContactTitle = "Accounting Manager";
            c.Address = "Torikatu 38";
            c.City = "Oulu";
            c.PostalCode = "90110";
            c.Country = "Finland";
            c.Phone = "981-443655";
            c.Fax = "981-443655";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "WELLI";
            c.CompanyName = "Wellington Importadora";
            c.Name = "Paula Parente";
            c.ContactTitle = "Sales Manager";
            c.Address = "Rua do Mercado, 12";
            c.City = "Resende";
            c.Region = "SP";
            c.PostalCode = "08737-363";
            c.Country = "Brazil";
            c.Phone = "(14) 555-8122";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "WHITC";
            c.CompanyName = "White Clover Markets";
            c.Name = "Karl Jablonski";
            c.ContactTitle = "Owner";
            c.Address = "305 - 14th Ave. S. Suite 3B";
            c.City = "Seattle";
            c.Region = "WA";
            c.PostalCode = "98128";
            c.Country = "USA";
            c.Phone = "(206) 555-4112";
            c.Fax = "(206) 555-4115";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "WILMK";
            c.CompanyName = "Wilman Kala";
            c.Name = "Matti Karttunen";
            c.ContactTitle = "Owner/Marketing Assistant";
            c.Address = "Keskuskatu 45";
            c.City = "Helsinki";
            c.PostalCode = "21240";
            c.Country = "Finland";
            c.Phone = "90-224 8858";
            c.Fax = "90-224 8858";
            custs.Add(c);

            c = new Customer();
            c.CustomerID = "WOLZA";
            c.CompanyName = "Wolski  Zajazd";
            c.Name = "Zbyszek Piestrzeniewicz";
            c.ContactTitle = "Owner";
            c.Address = "ul. Filtrowa 68";
            c.City = "Warszawa";
            c.PostalCode = "01-012";
            c.Country = "Poland";
            c.Phone = "(26) 642-7012";
            c.Fax = "(26) 642-7012";
            custs.Add(c);

            return custs;
        }
        public static IEnumerable<Customer> LoadCustomersFromMemoryNew()
        {
            var custs = new List<Customer> {
		        new Customer {CustomerID = "ALFKI", CompanyName = "Alfreds Futterkiste", Name = "Maria Anders", ContactTitle = "Sales Representative", Address = "Obere Str. 57", City = "Berlin", PostalCode = "12209", Country = "Germany", Phone = "030-0074321", Fax = "030-0076545"},
		        new Customer {CustomerID = "ANATR", CompanyName = "Ana Trujillo Emparedados y helados", Name = "Ana Trujillo", ContactTitle = "Owner", Address = "Avda. de la Constitución 2222", City = "México D.F.", PostalCode = "05021", Country = "Mexico", Phone = "(5) 555-4729", Fax = "(5) 555-3745"},
		        new Customer {CustomerID = "ANTON", CompanyName = "Antonio Moreno Taquería", Name = "Antonio Moreno", ContactTitle = "Owner", Address = "Mataderos  2312", City = "México D.F.", PostalCode = "05023", Country = "Mexico", Phone = "(5) 555-3932", },
		        new Customer {CustomerID = "AROUT", CompanyName = "Around the Horn", Name = "Thomas Hardy", ContactTitle = "Sales Representative", Address = "120 Hanover Sq.", City = "London", PostalCode = "WA1 1DP", Country = "UK", Phone = "(171) 555-7788", Fax = "(171) 555-6750"},
		        new Customer {CustomerID = "BERGS", CompanyName = "Berglunds snabbköp", Name = "Christina Berglund", ContactTitle = "Order Administrator", Address = "Berguvsvägen  8", City = "Luleå", PostalCode = "S-958 22", Country = "Sweden", Phone = "0921-12 34 65", Fax = "0921-12 34 67"},
		        new Customer {CustomerID = "BLAUS", CompanyName = "Blauer See Delikatessen", Name = "Hanna Moos", ContactTitle = "Sales Representative", Address = "Forsterstr. 57", City = "Mannheim", PostalCode = "68306", Country = "Germany", Phone = "0621-08460", Fax = "0621-08924"},
		        new Customer {CustomerID = "BLONP", CompanyName = "Blondesddsl père et fils", Name = "Frédérique Citeaux", ContactTitle = "Marketing Manager", Address = "24, place Kléber", City = "Strasbourg", PostalCode = "67000", Country = "France", Phone = "88.60.15.31", Fax = "88.60.15.32"},
		        new Customer {CustomerID = "BOLID", CompanyName = "Bólido Comidas preparadas", Name = "Martín Sommer", ContactTitle = "Owner", Address = "C/ Araquil, 67", City = "Madrid", PostalCode = "28023", Country = "Spain", Phone = "(91) 555 22 82", Fax = "(91) 555 91 99"},
		        new Customer {CustomerID = "BONAP", CompanyName = "Bon app'", Name = "Laurence Lebihan", ContactTitle = "Owner", Address = "12, rue des Bouchers", City = "Marseille", PostalCode = "13008", Country = "France", Phone = "91.24.45.40", Fax = "91.24.45.41"},
		        new Customer {CustomerID = "BOTTM", CompanyName = "Bottom-Dollar Markets", Name = "Elizabeth Lincoln", ContactTitle = "Accounting Manager", Address = "23 Tsawassen Blvd.", City = "Tsawassen", Region = "BC", PostalCode = "T2F 8M4", Country = "Canada", Phone = "(604) 555-4729", Fax = "(604) 555-3745"},
		        new Customer {CustomerID = "BSBEV", CompanyName = "B's Beverages", Name = "Victoria Ashworth", ContactTitle = "Sales Representative", Address = "Fauntleroy Circus", City = "London", PostalCode = "EC2 5NT", Country = "UK", Phone = "(171) 555-1212", },
		        new Customer {CustomerID = "CACTU", CompanyName = "Cactus Comidas para llevar", Name = "Patricio Simpson", ContactTitle = "Sales Agent", Address = "Cerrito 333", City = "Buenos Aires", PostalCode = "1010", Country = "Argentina", Phone = "(1) 135-5555", Fax = "(1) 135-4892"},
		        new Customer {CustomerID = "CENTC", CompanyName = "Centro comercial Moctezuma", Name = "Francisco Chang", ContactTitle = "Marketing Manager", Address = "Sierras de Granada 9993", City = "México D.F.", PostalCode = "05022", Country = "Mexico", Phone = "(5) 555-3392", Fax = "(5) 555-7293"},
		        new Customer {CustomerID = "CHOPS", CompanyName = "Chop-suey Chinese", Name = "Yang Wang", ContactTitle = "Owner", Address = "Hauptstr. 29", City = "Bern", PostalCode = "3012", Country = "Switzerland", Phone = "0452-076545", },
		        new Customer {CustomerID = "COMMI", CompanyName = "Comércio Mineiro", Name = "Pedro Afonso", ContactTitle = "Sales Associate", Address = "Av. dos Lusíadas, 23", City = "Sao Paulo", Region = "SP", PostalCode = "05432-043", Country = "Brazil", Phone = "(11) 555-7647", },
		        new Customer {CustomerID = "CONSH", CompanyName = "Consolidated Holdings", Name = "Elizabeth Brown", ContactTitle = "Sales Representative", Address = "Berkeley Gardens 12  Brewery", City = "London", PostalCode = "WX1 6LT", Country = "UK", Phone = "(171) 555-2282", Fax = "(171) 555-9199"},
		        new Customer {CustomerID = "DRACD", CompanyName = "Drachenblut Delikatessen", Name = "Sven Ottlieb", ContactTitle = "Order Administrator", Address = "Walserweg 21", City = "Aachen", PostalCode = "52066", Country = "Germany", Phone = "0241-039123", Fax = "0241-059428"},
		        new Customer {CustomerID = "DUMON", CompanyName = "Du monde entier", Name = "Janine Labrune", ContactTitle = "Owner", Address = "67, rue des Cinquante Otages", City = "Nantes", PostalCode = "44000", Country = "France", Phone = "40.67.88.88", Fax = "40.67.89.89"},
		        new Customer {CustomerID = "EASTC", CompanyName = "Eastern Connection", Name = "Ann Devon", ContactTitle = "Sales Agent", Address = "35 King George", City = "London", PostalCode = "WX3 6FW", Country = "UK", Phone = "(171) 555-0297", Fax = "(171) 555-3373"},
		        new Customer {CustomerID = "ERNSH", CompanyName = "Ernst Handel", Name = "Roland Mendel", ContactTitle = "Sales Manager", Address = "Kirchgasse 6", City = "Graz", PostalCode = "8010", Country = "Austria", Phone = "7675-3425", Fax = "7675-3426"},
		        new Customer {CustomerID = "FAMIA", CompanyName = "Familia Arquibaldo", Name = "Aria Cruz", ContactTitle = "Marketing Assistant", Address = "Rua Orós, 92", City = "Sao Paulo", Region = "SP", PostalCode = "05442-030", Country = "Brazil", Phone = "(11) 555-9857", },
		        new Customer {CustomerID = "FISSA", CompanyName = "FISSA Fabrica Inter. Salchichas S.A.", Name = "Diego Roel", ContactTitle = "Accounting Manager", Address = "C/ Moralzarzal, 86", City = "Madrid", PostalCode = "28034", Country = "Spain", Phone = "(91) 555 94 44", Fax = "(91) 555 55 93"},
		        new Customer {CustomerID = "FOLIG", CompanyName = "Folies gourmandes", Name = "Martine Rancé", ContactTitle = "Assistant Sales Agent", Address = "184, chaussée de Tournai", City = "Lille", PostalCode = "59000", Country = "France", Phone = "20.16.10.16", Fax = "20.16.10.17"},
		        new Customer {CustomerID = "FOLKO", CompanyName = "Folk och fä HB", Name = "Maria Larsson", ContactTitle = "Owner", Address = "Åkergatan 24", City = "Bräcke", PostalCode = "S-844 67", Country = "Sweden", Phone = "0695-34 67 21", },
		        new Customer {CustomerID = "FRANK", CompanyName = "Frankenversand", Name = "Peter Franken", ContactTitle = "Marketing Manager", Address = "Berliner Platz 43", City = "München", PostalCode = "80805", Country = "Germany", Phone = "089-0877310", Fax = "089-0877451"},
		        new Customer {CustomerID = "FRANR", CompanyName = "France restauration", Name = "Carine Schmitt", ContactTitle = "Marketing Manager", Address = "54, rue Royale", City = "Nantes", PostalCode = "44000", Country = "France", Phone = "40.32.21.21", Fax = "40.32.21.20"},
		        new Customer {CustomerID = "FRANS", CompanyName = "Franchi S.p.A.", Name = "Paolo Accorti", ContactTitle = "Sales Representative", Address = "Via Monte Bianco 34", City = "Torino", PostalCode = "10100", Country = "Italy", Phone = "011-4988260", Fax = "011-4988261"},
		        new Customer {CustomerID = "FURIB", CompanyName = "Furia Bacalhau e Frutos do Mar", Name = "Lino Rodriguez", ContactTitle = "Sales Manager", Address = "Jardim das rosas n. 32", City = "Lisboa", PostalCode = "1675", Country = "Portugal", Phone = "(1) 354-2534", Fax = "(1) 354-2535"},
		        new Customer {CustomerID = "GALED", CompanyName = "Galería del gastrónomo", Name = "Eduardo Saavedra", ContactTitle = "Marketing Manager", Address = "Rambla de Cataluña, 23", City = "Barcelona", PostalCode = "08022", Country = "Spain", Phone = "(93) 203 4560", Fax = "(93) 203 4561"},
		        new Customer {CustomerID = "GODOS", CompanyName = "Godos Cocina Típica", Name = "José Pedro Freyre", ContactTitle = "Sales Manager", Address = "C/ Romero, 33", City = "Sevilla", PostalCode = "41101", Country = "Spain", Phone = "(95) 555 82 82", },
		        new Customer {CustomerID = "GOURL", CompanyName = "Gourmet Lanchonetes", Name = "André Fonseca", ContactTitle = "Sales Associate", Address = "Av. Brasil, 442", City = "Campinas", Region = "SP", PostalCode = "04876-786", Country = "Brazil", Phone = "(11) 555-9482", },
		        new Customer {CustomerID = "GREAL", CompanyName = "Great Lakes Food Market", Name = "Howard Snyder", ContactTitle = "Marketing Manager", Address = "2732 Baker Blvd.", City = "Eugene", Region = "OR", PostalCode = "97403", Country = "USA", Phone = "(503) 555-7555", },
		        new Customer {CustomerID = "GROSR", CompanyName = "GROSELLA-Restaurante", Name = "Manuel Pereira", ContactTitle = "Owner", Address = "5ª Ave. Los Palos Grandes", City = "Caracas", Region = "DF", PostalCode = "1081", Country = "Venezuela", Phone = "(2) 283-2951", Fax = "(2) 283-3397"},
		        new Customer {CustomerID = "HANAR", CompanyName = "Hanari Carnes", Name = "Mario Pontes", ContactTitle = "Accounting Manager", Address = "Rua do Paço, 67", City = "Rio de Janeiro", Region = "RJ", PostalCode = "05454-876", Country = "Brazil", Phone = "(21) 555-0091", Fax = "(21) 555-8765"},
		        new Customer {CustomerID = "HILAA", CompanyName = "HILARION-Abastos", Name = "Carlos Hernández", ContactTitle = "Sales Representative", Address = "Carrera 22 con Ave. Carlos Soublette #8-35", City = "San Cristóbal", Region = "Táchira", PostalCode = "5022", Country = "Venezuela", Phone = "(5) 555-1340", Fax = "(5) 555-1948"},
		        new Customer {CustomerID = "HUNGC", CompanyName = "Hungry Coyote Import Store", Name = "Yoshi Latimer", ContactTitle = "Sales Representative", Address = "City Center Plaza 516 Main St.", City = "Elgin", Region = "OR", PostalCode = "97827", Country = "USA", Phone = "(503) 555-6874", Fax = "(503) 555-2376"},
		        new Customer {CustomerID = "HUNGO", CompanyName = "Hungry Owl All-Night Grocers", Name = "Patricia McKenna", ContactTitle = "Sales Associate", Address = "8 Johnstown Road", City = "Cork", Region = "Co. Cork", Country = "Ireland", Phone = "2967 542", Fax = "2967 3333"},
		        new Customer {CustomerID = "ISLAT", CompanyName = "Island Trading", Name = "Helen Bennett", ContactTitle = "Marketing Manager", Address = "Garden House Crowther Way", City = "Cowes", Region = "Isle of Wight", PostalCode = "PO31 7PJ", Country = "UK", Phone = "(198) 555-8888", },
		        new Customer {CustomerID = "KOENE", CompanyName = "Königlich Essen", Name = "Philip Cramer", ContactTitle = "Sales Associate", Address = "Maubelstr. 90", City = "Brandenburg", PostalCode = "14776", Country = "Germany", Phone = "0555-09876", },
		        new Customer {CustomerID = "LACOR", CompanyName = "La corne d'abondance", Name = "Daniel Tonini", ContactTitle = "Sales Representative", Address = "67, avenue de l'Europe", City = "Versailles", PostalCode = "78000", Country = "France", Phone = "30.59.84.10", Fax = "30.59.85.11"},
		        new Customer {CustomerID = "LAMAI", CompanyName = "La maison d'Asie", Name = "Annette Roulet", ContactTitle = "Sales Manager", Address = "1 rue Alsace-Lorraine", City = "Toulouse", PostalCode = "31000", Country = "France", Phone = "61.77.61.10", Fax = "61.77.61.11"},
		        new Customer {CustomerID = "LAUGB", CompanyName = "Laughing Bacchus Wine Cellars", Name = "Yoshi Tannamuri", ContactTitle = "Marketing Assistant", Address = "1900 Oak St.", City = "Vancouver", Region = "BC", PostalCode = "V3F 2K1", Country = "Canada", Phone = "(604) 555-3392", Fax = "(604) 555-7293"},
		        new Customer {CustomerID = "LAZYK", CompanyName = "Lazy K Kountry Store", Name = "John Steel", ContactTitle = "Marketing Manager", Address = "12 Orchestra Terrace", City = "Walla Walla", Region = "WA", PostalCode = "99362", Country = "USA", Phone = "(509) 555-7969", Fax = "(509) 555-6221"},
		        new Customer {CustomerID = "LEHMS", CompanyName = "Lehmanns Marktstand", Name = "Renate Messner", ContactTitle = "Sales Representative", Address = "Magazinweg 7", City = "Frankfurt a.M.", PostalCode = "60528", Country = "Germany", Phone = "069-0245984", Fax = "069-0245874"},
		        new Customer {CustomerID = "LETSS", CompanyName = "Let's Stop N Shop", Name = "Jaime Yorres", ContactTitle = "Owner", Address = "87 Polk St. Suite 5", City = "San Francisco", Region = "CA", PostalCode = "94117", Country = "USA", Phone = "(415) 555-5938", },
		        new Customer {CustomerID = "LILAS", CompanyName = "LILA-Supermercado", Name = "Carlos González", ContactTitle = "Accounting Manager", Address = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo", City = "Barquisimeto", Region = "Lara", PostalCode = "3508", Country = "Venezuela", Phone = "(9) 331-6954", Fax = "(9) 331-7256"},
		        new Customer {CustomerID = "LINOD", CompanyName = "LINO-Delicateses", Name = "Felipe Izquierdo", ContactTitle = "Owner", Address = "Ave. 5 de Mayo Porlamar", City = "I. de Margarita", Region = "Nueva Esparta", PostalCode = "4980", Country = "Venezuela", Phone = "(8) 34-56-12", Fax = "(8) 34-93-93"},
		        new Customer {CustomerID = "LONEP", CompanyName = "Lonesome Pine Restaurant", Name = "Fran Wilson", ContactTitle = "Sales Manager", Address = "89 Chiaroscuro Rd.", City = "Portland", Region = "OR", PostalCode = "97219", Country = "USA", Phone = "(503) 555-9573", Fax = "(503) 555-9646"},
		        new Customer {CustomerID = "MAGAA", CompanyName = "Magazzini Alimentari Riuniti", Name = "Giovanni Rovelli", ContactTitle = "Marketing Manager", Address = "Via Ludovico il Moro 22", City = "Bergamo", PostalCode = "24100", Country = "Italy", Phone = "035-640230", Fax = "035-640231"},
		        new Customer {CustomerID = "MAISD", CompanyName = "Maison Dewey", Name = "Catherine Dewey", ContactTitle = "Sales Agent", Address = "Rue Joseph-Bens 532", City = "Bruxelles", PostalCode = "B-1180", Country = "Belgium", Phone = "(02) 201 24 67", Fax = "(02) 201 24 68"},
		        new Customer {CustomerID = "MEREP", CompanyName = "Mère Paillarde", Name = "Jean Fresnière", ContactTitle = "Marketing Assistant", Address = "43 rue St. Laurent", City = "Montréal", Region = "Québec", PostalCode = "H1J 1C3", Country = "Canada", Phone = "(514) 555-8054", Fax = "(514) 555-8055"},
		        new Customer {CustomerID = "MORGK", CompanyName = "Morgenstern Gesundkost", Name = "Alexander Feuer", ContactTitle = "Marketing Assistant", Address = "Heerstr. 22", City = "Leipzig", PostalCode = "04179", Country = "Germany", Phone = "0342-023176", },
		        new Customer {CustomerID = "NORTS", CompanyName = "North/South", Name = "Simon Crowther", ContactTitle = "Sales Associate", Address = "South House 300 Queensbridge", City = "London", PostalCode = "SW7 1RZ", Country = "UK", Phone = "(171) 555-7733", Fax = "(171) 555-2530"},
		        new Customer {CustomerID = "OCEAN", CompanyName = "Océano Atlántico Ltda.", Name = "Yvonne Moncada", ContactTitle = "Sales Agent", Address = "Ing. Gustavo Moncada 8585 Piso 20-A", City = "Buenos Aires", PostalCode = "1010", Country = "Argentina", Phone = "(1) 135-5333", Fax = "(1) 135-5535"},
		        new Customer {CustomerID = "OLDWO", CompanyName = "Old World Delicatessen", Name = "Rene Phillips", ContactTitle = "Sales Representative", Address = "2743 Bering St.", City = "Anchorage", Region = "AK", PostalCode = "99508", Country = "USA", Phone = "(907) 555-7584", Fax = "(907) 555-2880"},
		        new Customer {CustomerID = "OTTIK", CompanyName = "Ottilies Käseladen", Name = "Henriette Pfalzheim", ContactTitle = "Owner", Address = "Mehrheimerstr. 369", City = "Köln", PostalCode = "50739", Country = "Germany", Phone = "0221-0644327", Fax = "0221-0765721"},
		        new Customer {CustomerID = "PARIS", CompanyName = "Paris spécialités", Name = "Marie Bertrand", ContactTitle = "Owner", Address = "265, boulevard Charonne", City = "Paris", PostalCode = "75012", Country = "France", Phone = "(1) 42.34.22.66", Fax = "(1) 42.34.22.77"},
		        new Customer {CustomerID = "PERIC", CompanyName = "Pericles Comidas clásicas", Name = "Guillermo Fernández", ContactTitle = "Sales Representative", Address = "Calle Dr. Jorge Cash 321", City = "México D.F.", PostalCode = "05033", Country = "Mexico", Phone = "(5) 552-3745", Fax = "(5) 545-3745"},
		        new Customer {CustomerID = "PICCO", CompanyName = "Piccolo und mehr", Name = "Georg Pipps", ContactTitle = "Sales Manager", Address = "Geislweg 14", City = "Salzburg", PostalCode = "5020", Country = "Austria", Phone = "6562-9722", Fax = "6562-9723"},
		        new Customer {CustomerID = "PRINI", CompanyName = "Princesa Isabel Vinhos", Name = "Isabel de Castro", ContactTitle = "Sales Representative", Address = "Estrada da saúde n. 58", City = "Lisboa", PostalCode = "1756", Country = "Portugal", Phone = "(1) 356-5634", },
		        new Customer {CustomerID = "PTC2 ", CompanyName = "C3", City = "C1", Country = "PT", },
		        new Customer {CustomerID = "QUEDE", CompanyName = "Que Delícia", Name = "Bernardo Batista", ContactTitle = "Accounting Manager", Address = "Rua da Panificadora, 12", City = "Rio de Janeiro", Region = "RJ", PostalCode = "02389-673", Country = "Brazil", Phone = "(21) 555-4252", Fax = "(21) 555-4545"},
		        new Customer {CustomerID = "QUEEN", CompanyName = "Queen Cozinha", Name = "Lúcia Carvalho", ContactTitle = "Marketing Assistant", Address = "Alameda dos Canàrios, 891", City = "Sao Paulo", Region = "SP", PostalCode = "05487-020", Country = "Brazil", Phone = "(11) 555-1189", },
		        new Customer {CustomerID = "QUICK", CompanyName = "QUICK-Stop", Name = "Horst Kloss", ContactTitle = "Accounting Manager", Address = "Taucherstraße 10", City = "Cunewalde", PostalCode = "01307", Country = "Germany", Phone = "0372-035188", },
		        new Customer {CustomerID = "RANCH", CompanyName = "Rancho grande", Name = "Sergio Gutiérrez", ContactTitle = "Sales Representative", Address = "Av. del Libertador 900", City = "Buenos Aires", PostalCode = "1010", Country = "Argentina", Phone = "(1) 123-5555", Fax = "(1) 123-5556"},
		        new Customer {CustomerID = "RATTC", CompanyName = "Rattlesnake Canyon Grocery", Name = "Paula Wilson", ContactTitle = "Assistant Sales Representative", Address = "2817 Milton Dr.", City = "Albuquerque", Region = "NM", PostalCode = "87110", Country = "USA", Phone = "(505) 555-5939", Fax = "(505) 555-3620"},
		        new Customer {CustomerID = "REGGC", CompanyName = "Reggiani Caseifici", Name = "Maurizio Moroni", ContactTitle = "Sales Associate", Address = "Strada Provinciale 124", City = "Reggio Emilia", PostalCode = "42100", Country = "Italy", Phone = "0522-556721", Fax = "0522-556722"},
		        new Customer {CustomerID = "RICAR", CompanyName = "Ricardo Adocicados", Name = "Janete Limeira", ContactTitle = "Assistant Sales Agent", Address = "Av. Copacabana, 267", City = "Rio de Janeiro", Region = "RJ", PostalCode = "02389-890", Country = "Brazil", Phone = "(21) 555-3412", },
		        new Customer {CustomerID = "RICSU", CompanyName = "Richter Supermarkt", Name = "Michael Holz", ContactTitle = "Sales Manager", Address = "Grenzacherweg 237", City = "Genève", PostalCode = "1203", Country = "Switzerland", Phone = "0897-034214", },
		        new Customer {CustomerID = "ROMEY", CompanyName = "Romero y tomillo", Name = "Alejandra Camino", ContactTitle = "Accounting Manager", Address = "Gran Vía, 1", City = "Madrid", PostalCode = "28001", Country = "Spain", Phone = "(91) 745 6200", Fax = "(91) 745 6210"},
		        new Customer {CustomerID = "SANTG", CompanyName = "Santé Gourmet", Name = "Jonas Bergulfsen", ContactTitle = "Owner", Address = "Erling Skakkes gate 78", City = "Stavern", PostalCode = "4110", Country = "Norway", Phone = "07-98 92 35", Fax = "07-98 92 47"},
		        new Customer {CustomerID = "SAVEA", CompanyName = "Save-a-lot Markets", Name = "Jose Pavarotti", ContactTitle = "Sales Representative", Address = "187 Suffolk Ln.", City = "Boise", Region = "ID", PostalCode = "83720", Country = "USA", Phone = "(208) 555-8097", },
		        new Customer {CustomerID = "SEVES", CompanyName = "Seven Seas Imports", Name = "Hari Kumar", ContactTitle = "Sales Manager", Address = "90 Wadhurst Rd.", City = "London", PostalCode = "OX15 4NB", Country = "UK", Phone = "(171) 555-1717", Fax = "(171) 555-5646"},
		        new Customer {CustomerID = "SIMOB", CompanyName = "Simons bistro", Name = "Jytte Petersen", ContactTitle = "Owner", Address = "Vinbæltet 34", City = "Kobenhavn", PostalCode = "1734", Country = "Denmark", Phone = "31 12 34 56", Fax = "31 13 35 57"},
		        new Customer {CustomerID = "SPECD", CompanyName = "Spécialités du monde", Name = "Dominique Perrier", ContactTitle = "Marketing Manager", Address = "25, rue Lauriston", City = "Paris", PostalCode = "75016", Country = "France", Phone = "(1) 47.55.60.10", Fax = "(1) 47.55.60.20"},
		        new Customer {CustomerID = "SPLIR", CompanyName = "Split Rail Beer & Ale", Name = "Art Braunschweiger", ContactTitle = "Sales Manager", Address = "P.O. Box 555", City = "Lander", Region = "WY", PostalCode = "82520", Country = "USA", Phone = "(307) 555-4680", Fax = "(307) 555-6525"},
		        new Customer {CustomerID = "SUPRD", CompanyName = "Suprêmes délices", Name = "Pascale Cartrain", ContactTitle = "Accounting Manager", Address = "Boulevard Tirou, 255", City = "Charleroi", PostalCode = "B-6000", Country = "Belgium", Phone = "(071) 23 67 22 20", Fax = "(071) 23 67 22 21"},
		        new Customer {CustomerID = "THEBI", CompanyName = "The Big Cheese", Name = "Liz Nixon", ContactTitle = "Marketing Manager", Address = "89 Jefferson Way Suite 2", City = "Portland", Region = "OR", PostalCode = "97201", Country = "USA", Phone = "(503) 555-3612", },
		        new Customer {CustomerID = "THECR", CompanyName = "The Cracker Box", Name = "Liu Wong", ContactTitle = "Marketing Assistant", Address = "55 Grizzly Peak Rd.", City = "Butte", Region = "MT", PostalCode = "59801", Country = "USA", Phone = "(406) 555-5834", Fax = "(406) 555-8083"},
		        new Customer {CustomerID = "TOMSP", CompanyName = "Toms Spezialitäten", Name = "Karin Josephs", ContactTitle = "Marketing Manager", Address = "Luisenstr. 48", City = "Münster", PostalCode = "44087", Country = "Germany", Phone = "0251-031259", Fax = "0251-035695"},
		        new Customer {CustomerID = "TORTU", CompanyName = "Tortuga Restaurante", Name = "Miguel Angel Paolino", ContactTitle = "Owner", Address = "Avda. Azteca 123", City = "México D.F.", PostalCode = "05033", Country = "Mexico", Phone = "(5) 555-2933", },
		        new Customer {CustomerID = "TRADH", CompanyName = "Tradição Hipermercados", Name = "Anabela Domingues", ContactTitle = "Sales Representative", Address = "Av. Inês de Castro, 414", City = "Sao Paulo", Region = "SP", PostalCode = "05634-030", Country = "Brazil", Phone = "(11) 555-2167", Fax = "(11) 555-2168"},
		        new Customer {CustomerID = "TRAIH", CompanyName = "Trail's Head Gourmet Provisioners", Name = "Helvetius Nagy", ContactTitle = "Sales Associate", Address = "722 DaVinci Blvd.", City = "Kirkland", Region = "WA", PostalCode = "98034", Country = "USA", Phone = "(206) 555-8257", Fax = "(206) 555-2174"},
		        new Customer {CustomerID = "VAFFE", CompanyName = "Vaffeljernet", Name = "Palle Ibsen", ContactTitle = "Sales Manager", Address = "Smagsloget 45", City = "Århus", PostalCode = "8200", Country = "Denmark", Phone = "86 21 32 43", Fax = "86 22 33 44"},
		        new Customer {CustomerID = "VICTE", CompanyName = "Victuailles en stock", Name = "Mary Saveley", ContactTitle = "Sales Agent", Address = "2, rue du Commerce", City = "Lyon", PostalCode = "69004", Country = "France", Phone = "78.32.54.86", Fax = "78.32.54.87"},
		        new Customer {CustomerID = "VINET", CompanyName = "Vins et alcools Chevalier", Name = "Paul Henriot", ContactTitle = "Accounting Manager", Address = "59 rue de l'Abbaye", City = "Reims", PostalCode = "51100", Country = "France", Phone = "26.47.15.10", Fax = "26.47.15.11"},
		        new Customer {CustomerID = "WANDK", CompanyName = "Die Wandernde Kuh", Name = "Rita Müller", ContactTitle = "Sales Representative", Address = "Adenauerallee 900", City = "Stuttgart", PostalCode = "70563", Country = "Germany", Phone = "0711-020361", Fax = "0711-035428"},
		        new Customer {CustomerID = "WARTH", CompanyName = "Wartian Herkku", Name = "Pirkko Koskitalo", ContactTitle = "Accounting Manager", Address = "Torikatu 38", City = "Oulu", PostalCode = "90110", Country = "Finland", Phone = "981-443655", Fax = "981-443655"},
		        new Customer {CustomerID = "WELLI", CompanyName = "Wellington Importadora", Name = "Paula Parente", ContactTitle = "Sales Manager", Address = "Rua do Mercado, 12", City = "Resende", Region = "SP", PostalCode = "08737-363", Country = "Brazil", Phone = "(14) 555-8122", },
		        new Customer {CustomerID = "WHITC", CompanyName = "White Clover Markets", Name = "Karl Jablonski", ContactTitle = "Owner", Address = "305 - 14th Ave. S. Suite 3B", City = "Seattle", Region = "WA", PostalCode = "98128", Country = "USA", Phone = "(206) 555-4112", Fax = "(206) 555-4115"},
		        new Customer {CustomerID = "WILMK", CompanyName = "Wilman Kala", Name = "Matti Karttunen", ContactTitle = "Owner/Marketing Assistant", Address = "Keskuskatu 45", City = "Helsinki", PostalCode = "21240", Country = "Finland", Phone = "90-224 8858", Fax = "90-224 8858"},
		        new Customer {CustomerID = "WOLZA", CompanyName = "Wolski  Zajazd", Name = "Zbyszek Piestrzeniewicz", ContactTitle = "Owner", Address = "ul. Filtrowa 68", City = "Warszawa", PostalCode = "01-012", Country = "Poland", Phone = "(26) 642-7012", Fax = "(26) 642-7012"}
            };
            return custs;
        }
        public static IEnumerable<Customer> LoadCustomersFromXML()
        {
            string customers = Resources.CustomersXMLFile;
            return
                XDocument.Parse(customers).
                Root.Elements("customer").
                Select(e => new Customer
                {
                    CustomerID = (string)e.Element("id"),
                    Name = (string)e.Element("name"),
                    Address = (string)e.Element("address"),
                    City = (string)e.Element("city"),
                    Region = (string)e.Element("region"),
                    PostalCode = (string)e.Element("postalcode"),
                    Country = (string)e.Element("country"),
                    Phone = (string)e.Element("phone"),
                    Fax = (string)e.Element("fax"),
                    Orders =
                        e.Elements("orders").Elements("order").
                        Select(o => new Order
                        {
                            OrderID = (int)o.Element("id"),
                            OrderDate = (DateTime)o.Element("orderdate"),
                            Total = (decimal)o.Element("total")
                        }).
                        ToArray()
                }).
                ToArray();
        }
    }

}