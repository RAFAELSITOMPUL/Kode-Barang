using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<int, (string, double)> daftarBarang = new Dictionary<int, (string, double)>
    {
        { 1, ("Beras 5kg", 75000) }, { 2, ("Minyak Goreng 2L", 35000) }, { 3, ("Gula 1kg", 15000) },
        { 4, ("Susu UHT 1L", 25000) }, { 5, ("Teh Celup", 10000) }, { 6, ("Kopi Bubuk", 20000) },
        { 7, ("Roti Tawar", 18000) }, { 8, ("Mie Instan", 3500) }, { 9, ("Sabun Mandi", 12000) },
        { 10, ("Shampoo 250ml", 30000) }, { 11, ("Pasta Gigi", 15000) }, { 12, ("Deterjen 1kg", 25000) },
        { 13, ("Tisu Gulung", 10000) }, { 14, ("Telur 1kg", 27000) }, { 15, ("Keju 250g", 45000) },
        { 16, ("Mentega 200g", 35000) }, { 17, ("Kecap Manis", 12000) }, { 18, ("Saus Sambal", 15000) },
        { 19, ("Minuman Soda", 12000) }, { 20, ("Air Mineral 1.5L", 5000) }, { 21, ("Biskuit Kaleng", 25000) },
        { 22, ("Kornet Sapi", 40000) }, { 23, ("Sosis 500g", 35000) }, { 24, ("Daging Ayam 1kg", 40000) },
        { 25, ("Daging Sapi 1kg", 120000) }, { 26, ("Ikan Lele 1kg", 35000) }, { 27, ("Sarden Kaleng", 20000) },
        { 28, ("Garam 500g", 5000) }, { 29, ("Merica Bubuk", 15000) }, { 30, ("Cabai Bubuk", 12000) },
        { 31, ("Gula Merah", 18000) }, { 32, ("Madu 250ml", 55000) }, { 33, ("Sirup Rasa Buah", 20000) },
        { 34, ("Mayonnaise 250g", 22000) }, { 35, ("Margarin 200g", 25000) }, { 36, ("Kecap Asin", 10000) },
        { 37, ("Sambal Botol", 12000) }, { 38, ("Keripik Kentang", 15000) }, { 39, ("Keripik Singkong", 12000) },
        { 40, ("Cokelat Batang", 25000) }, { 41, ("Minuman Isotonik", 12000) }, { 42, ("Yogurt 500ml", 18000) },
        { 43, ("Minuman Energi", 15000) }, { 44, ("Buah Apel 1kg", 35000) }, { 45, ("Buah Pisang 1 sisir", 25000) },
        { 46, ("Buah Jeruk 1kg", 30000) }, { 47, ("Sayur Bayam", 5000) }, { 48, ("Sayur Kangkung", 5000) },
        { 49, ("Wortel 1kg", 15000) }, { 50, ("Kentang 1kg", 25000) }
    };

    static void Main()
    {
        Console.Write("Masukkan nomor HP untuk daftar sebagai member: ");
        string noHp = Console.ReadLine();
        Console.WriteLine("Member berhasil terdaftar!\n");

        List<(string, int, double, double)> keranjang = new List<(string, int, double, double)>();
        double totalHarga = 0;

        while (true)
        {
            Console.WriteLine("\n--- Daftar Barang ---");
            foreach (var item in daftarBarang)
            {
                Console.WriteLine($"{item.Key}. {item.Value.Item1} - Rp{item.Value.Item2:N0}");
            }

            Console.Write("\nMasukkan nomor barang yang ingin dibeli (0 untuk selesai): ");
            int kodeBarang;
            if (!int.TryParse(Console.ReadLine(), out kodeBarang) || kodeBarang < 0 || kodeBarang > 50)
            {
                Console.WriteLine("Kode barang tidak valid.");
                continue;
            }
            if (kodeBarang == 0) break;

            Console.Write("Masukkan jumlah yang ingin dibeli: ");
            int jumlah;
            if (!int.TryParse(Console.ReadLine(), out jumlah) || jumlah <= 0)
            {
                Console.WriteLine("Jumlah tidak valid.");
                continue;
            }

            string namaBarang = daftarBarang[kodeBarang].Item1;
            double hargaSatuan = daftarBarang[kodeBarang].Item2;
            double subtotal = hargaSatuan * jumlah;

            double diskon = 0;
            if (jumlah >= 5) diskon = subtotal * 0.1;  // Diskon 10% untuk pembelian 5+ item
            if (jumlah >= 10) diskon = subtotal * 0.2; // Diskon 20% untuk pembelian 10+ item

            double hargaAkhir = subtotal - diskon;
            keranjang.Add((namaBarang, jumlah, hargaSatuan, hargaAkhir));
            totalHarga += hargaAkhir;

            Console.WriteLine($"Subtotal: Rp{subtotal:N0}, Diskon: Rp{diskon:N0}, Total: Rp{hargaAkhir:N0}");
        }

        CetakStruk(noHp, keranjang, totalHarga);
    }

    static void CetakStruk(string noHp, List<(string, int, double, double)> keranjang, double totalHarga)
    {
        Console.WriteLine("\n========== STRUK PEMBELIAN ==========");
        Console.WriteLine($"Member: {noHp}");
        Console.WriteLine("-------------------------------------");

        foreach (var item in keranjang)
        {
            Console.WriteLine($"{item.Item1} x{item.Item2} - Rp{item.Item3:N0} = Rp{item.Item4:N0}");
        }

        Console.WriteLine("-------------------------------------");
        Console.WriteLine($"Total Pembayaran: Rp{totalHarga:N0}");
        Console.WriteLine("Terima kasih telah berbelanja di minimarket kami!");
        Console.WriteLine("=====================================");
    }
}
