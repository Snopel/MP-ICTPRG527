using System;

namespace SubnetMask
{
    class Program
    {
        static void Main(string[] args)
        {
            int hostBit = 0;
            int bitPos = 256;
            int[] binary = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int subChoice = 0;
            bool reboot = false;

            do
            {
                reboot = false;
                try
                {
                    Console.Write("Select a subnet class." +
                        "\n1: Class C (255.255.255.___)" +
                        "\n2: Class B (255.255.___.___)" +
                        "\n3: Class A (255.___.___.___)" +
                        "\n\nChoice: ");

                    subChoice = Convert.ToInt32(Console.ReadLine());

                    //From a VLSN of 255.255.255.___
                    Console.Write("\nHost Bits to borrow: ");
                    hostBit = Convert.ToInt32(Console.ReadLine());

                    //If input is out of range of the hostbits
                    if (hostBit >= 8 || hostBit < 1)
                    {
                        throw new Exception();
                    }


                    switch (subChoice)
                    {
                        case 1:
                            ClassCDesc(hostBit, bitPos, binary);
                            break;

                        case 2:
                            ClassBDesc(hostBit, bitPos, binary);
                            break;

                        case 3:
                            break;

                        default:
                            throw new Exception();
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input. Rebooting...\n\n#########################\n");
                    reboot = true;
                }
            } while (reboot);

            Console.ReadLine();
        }

        //For Subnet 255.255.255.___
        static void ClassCDesc(int hostBit, int bitPos, int[] binary)
        {
            //Final Subnet Mask
            for (int i = 0; i < hostBit; i++)
            {
                bitPos /= 2; //Finding the value of the host bit
                binary[i] = 1; //Changing the array into binary
            }
            Console.WriteLine("\nSubnet Mask: 255.255.255." + (256 - bitPos));
            Console.Write("In Binary: 11111111.11111111.11111111.");
            ArraySpill(binary);

            //Hostbits left
            Console.WriteLine("\nRemaining Hostbits: " + (8 - hostBit));

            //Number of subnets
            Console.WriteLine("Number of Subnetworks: " + Math.Pow(2, hostBit));
            //Hosts per Subnet
            Console.WriteLine("Hosts per Subnet: " + bitPos);
            Console.WriteLine("Usable Hosts per Subnet: " + (bitPos - 2));

            //CIDR
            Console.WriteLine("CIDR: /" + (hostBit + 24));
        }

        //For Subnet 255.255.255.___
        static void ClassBDesc(int hostBit, int bitPos, int[] binary)
        {
            //Final Subnet Mask
            for (int i = 0; i < hostBit; i++)
            {
                bitPos /= 2; //Finding the value of the host bit
                binary[i] = 1; //Changing the array into binary
            }
            Console.WriteLine("\nSubnet Mask: 255.255." + (256 - bitPos) + ".0");
            Console.Write("In Binary: 11111111.11111111.");
            ArraySpill(binary);
            Console.WriteLine(".00000000");

            //Hostbits left
            Console.WriteLine("Remaining Hostbits: " + (16 - hostBit));

            //Number of subnets
            Console.WriteLine("Number of Subnets: " + Math.Pow(0, 2));
            //Hosts per Subnet
            Console.WriteLine("Hosts per Subnet: " + bitPos);
            Console.WriteLine("Usable Hosts per Subnet: " + (bitPos - 2));

            //CIDR
            Console.WriteLine("CIDR: /" + (hostBit + 16));
        }

        static void ArraySpill(int[] arr)
        {
            for(int i = 0; i < 8; i++)
            {
                Console.Write(arr[i]);
            }
        }
    }
}
