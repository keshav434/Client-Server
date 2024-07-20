
using System.Net.Sockets;
using System.Net;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Net.Sockets;
using System.IO;
using System.Net;
using MySqlX.XDevAPI.Common;
using DandN;
using MySql.Data.MySqlClient;

Boolean debug = true;

Dictionary<string, User> DataBase = new Dictionary<string, User>
{
    {"cssbct",
      new User {UserID="cssbct",Surname="Tompsett",Fornames="Brian C",Title="Eur Ing",
        Position="Lecturer of Computer Science",
        Phone="+44 1482 46 5222",Email="B.C.Tompsett@hull.ac.uk",Location="in RB-336" }
    }
};

if (args.Length == 0)
{
    Console.WriteLine("Starting Server");
    RunServer();
}
else
{
    for (int i = 0; i < args.Length; i++)
    {
        ProcessCommand(args[i]);
    }
}




/// Process the next database command request
 void ProcessCommand(string command)
{
    if (debug) Console.WriteLine($"\nCommand: {command}");
    try
    {
        string[] slice = command.Split(new char[] { '?' }, 2);

        string operation = null;
        string update = null;
        string field = null;
        string ID = slice[0];
        if (slice.Length == 2)
        {
            operation = slice[1];
            string[] pieces = operation.Split(new char[] { '=' }, 2);
            field = pieces[0];
            if (pieces.Length == 2) update = pieces[1];
        }
        if (debug) Console.Write($"Operation on ID '{ID}'");
        if (operation == null)
        {
            Dump(command);
        }
        else if (update == null)
        { 
            Lookup(ID, field);
        }
        else
        {
            Update(ID, field, update);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Fault in Command Processing: {e.ToString()}");
    }

}

/// Functions to process database requests
void Dump(string ID)
{
    if (debug) Console.WriteLine(" Dump");
    //Console.WriteLine($"UserID={DataBase[ID].UserID}");
    //Console.WriteLine($"Surname={DataBase[ID].Surname}");
    //Console.WriteLine($"Fornames={DataBase[ID].Fornames}");
    //Console.WriteLine($"Title={DataBase[ID].Title}");
    //Console.WriteLine($"Position={DataBase[ID].Position}");
    //Console.WriteLine($"Phone={DataBase[ID].Phone}");
    //Console.WriteLine($"Email={DataBase[ID].Email}");
    //Console.WriteLine($"location={DataBase[ID].Location}");

    string connStr = "server=localhost; user=root; database= clients; port=3306; password = K.p37883HUSU";
    MySqlConnection conn = new MySqlConnection(connStr);
    try
    {
        Console.WriteLine("Connecting to MySQL--- world database");
        conn.Open();
        string sql = "Select Users_Tab.UserID, Users_Tab.Surname, Fornames_Tab.Forname, users_tab.title,  positions_tab.Positionc ,phone_Tab.Phone, Emails_Tab.Email_id , location_tab.Location from Users_Tab  INNER JOIN location_tab ON Users_Tab.LocationSlNo = location_tab.LocationSlNo INNER JOIN positions_tab ON users_tab.PositionSlNo = positions_tab.PositionSlNo INNER JOIN Phone_Tab ON Users_Tab.PhoneSlNo = phone_tab.PhoneSlNo INNER JOIN Emails_Tab ON Users_Tab.EmailSlNo = Emails_Tab.EmailSlNo INNER JOIN Fornames_Tab ON Users_Tab.FornameSlNo = Fornames_Tab.FornameSlNo  INNER JOIN Login_Tab1 ON Users_Tab.LoginSlNo = login_tab1.LoginSlNo  Where Login_Tab1.Login_ID =" + ID;
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        MySqlDataReader rdr = cmd.ExecuteReader();
        Console.WriteLine("UserID - Surname - Forname -    - Title -  Position     -  Phonenumber - Email -   Location  ");
        while (rdr.Read())
        {

            Console.WriteLine(rdr[0] + " - " + rdr[1] + " - " + rdr[2] + " - " + rdr[3] + " - " + rdr[4] + " - " + rdr[5] + " - " + rdr[6] + " - " + rdr[7] );

        }
        rdr.Close();

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
    Console.WriteLine("Done the job");
}
void Lookup(string ID, string field)
{
    if (debug)
        Console.WriteLine($" lookup field '{field}'");
    string result = null;
    switch (field)
    {
        case "location": result = DataBase[ID].Location; break;
        case "UserID": result = DataBase[ID].UserID; break;
        case "Surname": result = DataBase[ID].Surname; break;
        case "Fornames": result = DataBase[ID].Fornames; break;
        case "Title": result = DataBase[ID].Title; break;
        case "Phone": result = DataBase[ID].Phone; break;
        case "Position": result = DataBase[ID].Position; break;
        case "Email": result = DataBase[ID].Email; break;
    }
    Console.WriteLine(result);
}
void Update(string ID, string field, string update)
{
    if (debug)
        Console.WriteLine($" update field '{field}' to '{update}'");
    switch (field)
    {
        case "location": DataBase[ID].Location = update; break;
        case "UserID": DataBase[ID].UserID = update; break;
        case "Surname": DataBase[ID].Surname = update; break;
        case "Fornames": DataBase[ID].Fornames = update; break;
        case "Title": DataBase[ID].Title = update; break;
        case "Phone": DataBase[ID].Phone = update; break;
        case "Position": DataBase[ID].Position = update; break;
        case "Email": DataBase[ID].Email = update; break;
    }
    Console.WriteLine("OK");
}



/// Initiate the Web Server task
void RunServer()
{
    TcpListener listener;
    Socket connection;
    NetworkStream socketStream;
    try
    {
        listener = new TcpListener(IPAddress.Any, 43);
        listener.Start();
        while (true)
        {
            if (debug) Console.WriteLine("Server Waiting connection...");
            connection = listener.AcceptSocket();
            connection.SendTimeout = 1000;
            connection.ReceiveTimeout = 1000;
            socketStream = new NetworkStream(connection);
            doRequest(socketStream);
            socketStream.Close();
            connection.Close();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Exception: " + e.ToString());   //log.log(e.ToString()) a class called log which had a logging function 
    }
    if (debug)
        Console.WriteLine("Terminating Server");


}
void doRequest(NetworkStream socketStream)
{



    StreamWriter sw = new StreamWriter(socketStream);
    StreamReader sr = new StreamReader(socketStream);
    if (debug) Console.WriteLine("Waiting for input from client...");
    try
    {
        string line = sr.ReadLine();
        Console.WriteLine($"Received Network Command: '{line}'");
        if (line == null)
        {
            if (debug) Console.WriteLine("Ignoring null command");
            return;
        }
        if (line == "POST / HTTP/1.1")
        {
            int content_length = 0;                      //   string[] slices = line.Split(" ");  // Split into 3 pieces
            while (line != "")
            {
                if (line.StartsWith("Content-Length: "))
                {
                    content_length = Int32.Parse(line.Substring(16));
                }
                line = sr.ReadLine();
                if (debug) Console.WriteLine($"Skipped Header Line: '{line}'");
            }                                                                       // string ID = slices[1].Substring(7);  // start at the 7th letter of the middle slice - skip `/?name=`
            for (int i = 0; i < content_length; i++) line += (char)sr.Read();                                            // string field = slices[2].Substring(7);
            String[] slices = line.Split(new char[] { '&' }, 2);
            String ID = slices[0].Substring(5);
            String value = slices[1].Substring(9);
            if (debug) Console.WriteLine($"Received an update request for '{ID}' to '{value}'");                                                                                                            // string newvalue = slices[3];
                                                                                                                                                                                                            //  Update(ID, field, newvalue);
                                                                                                                                                                                                            // The we have an update
            DataBase["cssbct"].Location = "network update test string";
            if (debug) Console.WriteLine("Received an update request");
        }
        else if (line.StartsWith("GET /?name=") && line.EndsWith(" HTTP/1.1"))
        {
            // then we have a lookup
            if (debug) Console.WriteLine("Received a lookup request");
            string[] slices = line.Split(" ");  // Split into 3 pieces
            string ID = slices[1].Substring(7);  // start at the 7th letter of the middle slice - skip `/?name=`

            if (DataBase.ContainsKey(ID))
            {
                string result = DataBase[ID].Location;

                sw.WriteLine("HTTP/1.1 200 OK");
                sw.WriteLine("Content-Type: text/plain");
                sw.WriteLine();
                sw.WriteLine(result);
                sw.Flush();
                Console.WriteLine($"Performed Lookup on '{ID}' returning '{result}'");
            }
            else
            {
                // Not found
                sw.WriteLine("HTTP/1.1 404 Not Found");
                sw.WriteLine("Content-Type: text/plain");
                sw.WriteLine();
                sw.Flush();
                Console.WriteLine($"Performed Lookup on '{ID}' returning '404 Not Found'");
            }
        }
        else
        {
            // We have an error
            Console.WriteLine($"Unrecognised command: '{line}'");
            sw.WriteLine("HTTP/1.1 400 Bad Request");
            sw.WriteLine("Content-Type: text/plain");
            sw.WriteLine();
            sw.Flush();
        }


        // sw.WriteLine(line);//Need to remove this line after testing 
        // sw.Flush();        //Need to remove this line after testing
        //Console.WriteLine(sr.ReadToEnd());
    }
    catch
    {
        Console.WriteLine("Something Went wrong");
    }
}

