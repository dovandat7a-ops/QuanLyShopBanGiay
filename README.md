# Đồ án: Quản Lý Shop Bán Giày

## Giới thiệu
Phần mềm quản lý shop bán giày, được xây dựng bằng C# WinForms, kết nối SQL Server.
Đây là đồ án môn học VB.

## Chức năng chính
- Quản lý Khách hàng (Thêm, Sửa, Xóa, Tìm kiếm)
- Quản lý Sản phẩm (Thêm, Sửa, Xóa, Tìm kiếm)
- Quản lý Nhân viên
- Quản lý Nhà cung cấp
- Quản lý Đơn hàng & Chi tiết đơn hàng

## Cơ sở dữ liệu
- Sử dụng SQL Server LocalDB.
- Khi chạy lần đầu, chương trình tự động tạo database `QuanLyShopGiay`.
- File script SQL đi kèm: `QuanLyShopGiay.sql`

## Cách chạy
1. Mở project `QuanLyShopBanGiay.sln` bằng Visual Studio 2022.
2. Nhấn **F5** để chạy.
3. Menu "Quản lý" → chọn từng mục để mở form CRUD.

## Dữ liệu mẫu
Bảng `Product` có sẵn 5 sản phẩm mẫu (Nike, Adidas, Converse, Vans, Bitis).
