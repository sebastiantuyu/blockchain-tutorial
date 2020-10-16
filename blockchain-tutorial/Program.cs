using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using static System.Console;

namespace blockchain_tutorial
{
    class Program
    {

        class Block
        {

            //PROPIEDADES DE LA CLASE
            public byte[] hash { get; set; }
            public string data { get; set; }
            public int nonce { get; set; }

            public Block(int nonce, string data, byte[] hash)
            {
                this.hash = hash;
                this.data = data;
                this.nonce = nonce;
            }

            public byte[] generate_hash()
            {
                string complete = Convert.ToString(this.nonce) + this.data; 
                byte[] c_byte = Encoding.ASCII.GetBytes(complete),conver;
                SHA256 sha = SHA256.Create();
                conver = sha.ComputeHash(c_byte);
                return conver;
            }

            public int generate_genesis()
            {
                this.nonce = 0;
                this.data = "SatoshiTOBob100";
                this.hash = generate_hash();
                return 0;
            }


        }

        class Blockchain
        {
            
            public byte[] prev_hash { get; set; }
             
             
        }


        static void Main(string[] args)
        {


            List<Block> blockchain = new List<Block>();
            string user1, user2;
            double amount;

            for (int i=0; i < 3; i++){
                
                WriteLine("INTRODUZCA EL USUARIO QUE ENVIA");
                user1 = ReadLine();
                WriteLine("Introduzca el usaurio que RECIBE");
                user2 = ReadLine();
                WriteLine("¿Cuanto desea enviar?");
                amount = Convert.ToDouble(ReadLine());
  
                    blockchain.Add(new Block(blockchain.Count + 1,
                                            DataFormat(user1, user2, amount),
                                            generate_hash(blockchain.Count + 1, DataFormat(user1, user2, amount))));
                
                WriteLine("----------------------------------------------");
                WriteLine($"BLOQUE #{blockchain.Count} ES:");
                PrintBytes(blockchain[blockchain.Count - 1].hash);
                WriteLine("\n");
                WriteLine("----------------------------------------------");
                
            }

        }
        static byte[] generate_hash(int nonce,string data)
        {
            string complete = Convert.ToString(nonce) + data;
            byte[] c_byte = Encoding.ASCII.GetBytes(complete), conver;
            SHA256 sha = SHA256.Create();
            conver = sha.ComputeHash(c_byte);
            return conver;
        }
        static string DataFormat(string user1,string user2,double amount)
        {
            string data;
            data = $"{user1}TO{user2}:{amount}";
            return data;
        }

        static double SecondsNow()
        {
            double sec;
            TimeSpan tI = TimeSpan.Parse(DateTime.Now.ToString("hh:mm:ss"));
            sec = tI.TotalSeconds;
            return sec;
        }
        static double CalculateTime()
        {
            TimeSpan ti = TimeSpan.Parse(DateTime.Now.ToString("hh:mm:ss"));
            TimeSpan tf = TimeSpan.Parse("00:02:45");
            TimeSpan result = ti.Add(tf);
            return result.TotalSeconds;

        }

        static void PrintBytes(byte[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Write($"{array[i]:X2}");

            }
        }
    }



}
