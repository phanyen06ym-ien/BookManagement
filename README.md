
# Book Management

## Giới thiệu

Book Management là ứng dụng Web quản lý sách được xây dựng bằng **ASP.NET Core MVC**.

Ứng dụng sử dụng **Entity Framework Core (ORM)** để làm việc với cơ sở dữ liệu **SQL Server** theo phương pháp **Code First**.

Project được tiếp tục phát triển với **Middleware** để ghi log request, theo dõi Status Code và chặn một số request không hợp lệ.

---

## Chức năng

### Quản lý sách

- Hiển thị danh sách sách
- Thêm sách mới
- Xem chi tiết sách
- Chỉnh sửa thông tin sách
- Xóa sách
- Kiểm tra dữ liệu nhập vào bằng Data Annotation và ModelState

### Middleware

Project có `RequestLoggingMiddleware` để xử lý request trước và sau Controller.

Các chức năng gồm:

- Ghi thời gian truy cập
- Ghi HTTP Method: GET / POST
- Ghi đường dẫn request
- Ghi Status Code sau khi request được xử lý
- Chặn Book ID không hợp lệ
- Trả về Status Code `400` khi truy cập:
  - `/Books/Details/0`
  - `/Books/Details/-1`

Ví dụ log:

```text
[2026-10-07 01:20:15.347] Method: GET - Path: /Books
Status Code: 200

[2026-10-07 01:21:10.125] Method: GET - Path: /Books/Details/1
Status Code: 200

[2026-10-07 01:22:30.542] Method: POST - Path: /Books/Create
Status Code: 302
```

---

## Thông tin sách

Mỗi sách gồm các thông tin:

- Mã sách
- Tên sách
- Tác giả
- Giá
- Số lượng
- Năm xuất bản

---

## Công nghệ sử dụng

- ASP.NET Core MVC
- .NET 10
- Entity Framework Core
- SQL Server / LocalDB
- Entity Framework Core Code First
- Middleware
- Bootstrap

---

## Cơ sở dữ liệu

Project sử dụng **Entity Framework Core Code First**.

Model `Book` được xây dựng trước trong code, sau đó sử dụng Migration để tạo và cập nhật cấu trúc cơ sở dữ liệu.

Lệnh tạo Migration:

```powershell
Add-Migration InitialCreate
```

Lệnh cập nhật database:

```powershell
Update-Database
```

Database sử dụng:

```text
BookManagementDB
```

---

## Cấu trúc chính của project

```text
BookManagement
│
├── Controllers
│   └── BooksController.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Middlewares
│   └── RequestLoggingMiddleware.cs
│
├── Models
│   └── Book.cs
│
├── Views
│   └── Books
│       ├── Index.cshtml
│       ├── Create.cshtml
│       ├── Edit.cshtml
│       ├── Details.cshtml
│       └── Delete.cshtml
│
├── Migrations
│
└── Program.cs
```

---

# Video thuyết trình và Demo

## Bài tập 4 – Book Management CRUD, Validation, EF Core và Code First

Nội dung demo:

- Cấu trúc ASP.NET Core MVC
- Model `Book`
- Data Annotation và Validation
- Entity Framework Core ORM
- Code First và Migration
- SQL Server
- CRUD:
  - Create
  - Read
  - Update
  - Delete

🎥 **Video Bài tập 4:**  
[▶ Xem video Bài tập 4](https://drive.google.com/file/d/1FDMH54V9bKbf2Yks_qpJz5EuHEEa5DoS/view?usp=sharing)

---

## Bài tập 5 – Middleware trong xử lý Back-end Web

Nội dung demo:

- Tạo `RequestLoggingMiddleware`
- Đăng ký Middleware trong `Program.cs`
- Ghi thời gian request
- Ghi Method GET / POST
- Ghi Path
- Ghi Status Code
- Xử lý trước và sau `await _next(context)`
- Chặn Book ID không hợp lệ
- Trả Status Code `400`

🎥 **Video Bài tập 5:**  
[▶ Xem video Bài tập 5](https://drive.google.com/file/d/117lIjDt9qCS5eyN8u0MDKGBES7Z8YTsD/view?usp=sharing)

---

## Người thực hiện

**Họ và tên:** Phan Hải Yến
