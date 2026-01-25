# WebBanHang – ASP.NET Core

## 📦 Môi trường sử dụng

* **.NET SDK**: `9.0.102`
* **ASP.NET Core**: .NET 9
* **Entity Framework Core**
* **MySQL** (Pomelo.EntityFrameworkCore.MySql)

---

## 🚀 Build source

Trước khi chạy project, cần restore package và build source:

```bash
dotnet restore
dotnet build
```

---

## 🗂️ Migration (Entity Framework Core)

### 1️⃣ Tạo migration

Lệnh này dùng để sinh migration từ DbContext (chưa tạo database):

```bash
dotnet ef migrations add InitialCreate
```

📌 Kết quả:

* Tạo thư mục `Migrations/`
* Lưu lại cấu trúc database bằng code

---

### 2️⃣ Tạo hoặc cập nhật database

Lệnh này áp dụng migration vào database:

```bash
dotnet ef database update
```

📌 Chức năng:

* Tạo database **nếu chưa tồn tại**
* Tạo / cập nhật bảng theo migration
* Tạo bảng `__EFMigrationsHistory`

---

## 🧠 Quy trình chuẩn khi làm việc với EF Core

```text
Thay đổi Model
      ↓
dotnet ef migrations add <MigrationName>
      ↓
dotnet ef database update
```

---

## ⚠️ Lưu ý

* Đảm bảo connection string MySQL đúng trong `appsettings.json`
* User MySQL phải có quyền `CREATE`, `ALTER`
* Nếu gặp lỗi build → chạy lại:

  ```bash
  dotnet clean
  dotnet build
  ```

---

## 📁 Các lệnh thường dùng

```bash
dotnet restore                                               # Restore NuGet packages
dotnet build                                                 # Build project
dotnet ef migrations add <MigrationName>                     # Tạo migration
dotnet ef migrations list                                    # Xem danh sách migration
dotnet ef database update                                    # Update database
dotnet ef migrations remove                                  # Xóa migration cuối (chưa apply DB)
```

---
