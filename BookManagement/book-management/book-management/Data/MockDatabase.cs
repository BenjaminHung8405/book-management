using System;
using System.Collections.Generic;
using System.Dynamic;

namespace book_management.Data
{
    // Simple in-memory mock database for UI testing (dynamic objects)
    public static class Database
    {
        // Return mock list of dynamic books mapped from provided JSON
        public static List<dynamic> GetAllBooks()
        {
            var list = new List<dynamic>();

            dynamic b1 = new ExpandoObject();
            b1.SachId = 1;
            b1.TenSach = "The Amazing Spider-Man (1963)";
            b1.TacGia = "Stan Lee";
            b1.Gia = 120000m;
            b1.AnhBiaUrl = "https://m.media-amazon.com/images/I/91lwuGWNjsL._SL1500_.jpg";
            list.Add(b1);

            dynamic b2 = new ExpandoObject();
            b2.SachId = 2;
            b2.TenSach = "Ant-Man & The Wasp";
            b2.TacGia = "Stan Lee";
            b2.Gia = 95000m;
            b2.AnhBiaUrl = "https://m.media-amazon.com/images/I/81-o3LZ0jLL._SL1500_.jpg";
            list.Add(b2);

            dynamic b3 = new ExpandoObject();
            b3.SachId = 3;
            b3.TenSach = "The Invincible Iron Man";
            b3.TacGia = "Stan Lee";
            b3.Gia = 140000m;
            b3.AnhBiaUrl = "https://m.media-amazon.com/images/I/91y-KuI3yCL._AC_SL1500_.jpg";
            list.Add(b3);

            dynamic b4 = new ExpandoObject();
            b4.SachId = 4;
            b4.TenSach = "Marvel Zombies";
            b4.TacGia = "Stan Lee";
            b4.Gia = 60000m;
            b4.AnhBiaUrl = "http://1.bp.blogspot.com/-vNUqD-HUcdQ/Vp5GXqrP7fI/AAAAAAAAIEE/OSIFYvS3D7k/s1600/0.jpg";
            list.Add(b4);

            dynamic b5 = new ExpandoObject();
            b5.SachId = 5;
            b5.TenSach = "Doraemon";
            b5.TacGia = "Fujiko F. Fujio";
            b5.Gia = 75000m;
            b5.AnhBiaUrl = "https://manga-mon.com/cdn/shop/files/Doraemon_3Front.jpg?v=1689893030&width=600";
            list.Add(b5);

            dynamic b6 = new ExpandoObject();
            b6.SachId = 6;
            b6.TenSach = "Dragon Ball";
            b6.TacGia = "Toriyama Akira";
            b6.Gia = 85000m;
            b6.AnhBiaUrl = "https://m.media-amazon.com/images/I/511NPC9V4GL.jpg";
            list.Add(b6);

            dynamic b7 = new ExpandoObject();
            b7.SachId = 7;
            b7.TenSach = "Cable";
            b7.TacGia = "Stan Lee";
            b7.Gia = 68000m;
            b7.AnhBiaUrl = "https://images-na.ssl-images-amazon.com/images/S/cmx-images-prod/Item/494347/494347._SX1280_QL80_TTD_.jpg";
            list.Add(b7);

            return list;
        }

        // Simple helper to map tacgia_id to a name for UI (kept for compatibility)
        public static string GetAuthorName(int tacgiaId)
        {
            switch (tacgiaId)
            {
                case 1: return "Stan Lee";
                case 2: return "Fujiko F. Fujio";
                case 3: return "Toriyama Akira";
                default: return "Unknown";
            }
        }
    }
}
