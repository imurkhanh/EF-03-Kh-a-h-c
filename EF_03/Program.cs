using EF_03.IService;
using EF_03.Service;

void Main()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.InputEncoding = System.Text.Encoding.UTF8;
    IHocVienService hocVienService = new HocVienService();
    IKhoaHocService khoaHocService = new KhoaHocService();
    INgayHocService ngayHocService = new NgayHocService();

    Console.WriteLine("------------------------------QUẢN LÝ KHÓA HỌC(EF-03)------------------------------");
    Console.WriteLine("1. Thêm ngày học");
    Console.WriteLine("2. Sửa thông tin học viên");
    Console.WriteLine("3. Xóa khóa học");
    Console.WriteLine("4. Tìm kiếm học viên theo họ tên và khóa học");
    Console.WriteLine("5. Tính doanh thu của trung tâm trong 1 tháng");
    Console.WriteLine("6. Thoát chương trình");
    string choice;
    do
    {
        Console.WriteLine();
        Console.Write("Chọn chức năng(1-6): ");
        choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                ngayHocService.ThemNgayHoc();
                break;
            case "2":
                hocVienService.SuaHocVien();
                break;
            case "3":
                khoaHocService.XoaKhoaHoc();
                break;
            case "4":
                hocVienService.TimKiemHocVienTheoHoTen_KhoaHoc();
                break;
            case "5":
                khoaHocService.TinhDoanhThuTheoThang();
                break;
            case "6":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                break;
        }
    } while (choice != "6");
}
Main();