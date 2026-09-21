# COMP1019 - Lập trình trên Windows
## BUỔI 4 - LAB 04: Exception, Delegate/Event, Func/Action và Generic trong C#

**Thông tin chung:**
*   **Thời lượng gợi ý:** 75-90 phút thực hành trên lớp và hoàn thiện ở nhà
*   **Hình thức:** Cá nhân
*   **Công cụ:** Visual Studio, project Console App C#

---

## 1. Mục tiêu lab
*   Vận dụng `try-catch`, `throw` và exception tự tạo để xử lý lỗi trong chương trình.
*   Sử dụng delegate/event hoặc Action event để thông báo khi dữ liệu thay đổi.
*   Sử dụng `Func<T,bool>` để lọc và tìm kiếm dữ liệu theo điều kiện.
*   Xây dựng generic class `Repository<T>` để quản lý danh sách đối tượng.
*   Tổ chức code rõ ràng, không viết toàn bộ xử lý trong Main.

## 2. Mô tả bài toán
Viết chương trình Console quản lý sản phẩm. Dữ liệu được lưu trong bộ nhớ bằng một `Repository<T>`. Chương trình phải xử lý lỗi nhập liệu, mã sản phẩm trùng và sản phẩm không tồn tại bằng exception phù hợp.

## 3. Yêu cầu class

| Thành phần | Nội dung | Yêu cầu |
| :--- | :--- | :--- |
| **IEntity** | `string Id { get; }` | Dùng làm ràng buộc generic cho `Repository<T>`. |
| **Product** | MaSP, TenSP, Price, Quantity | Có constructor, property, ToString. Price và Quantity không được âm. |
| **DuplicateProductException** | Exception tự tạo | Phát sinh khi thêm sản phẩm có mã bị trùng. |
| **ProductNotFoundException** | Exception tự tạo | Phát sinh khi xóa hoặc sửa sản phẩm không tồn tại. |
| **Repository<T>** | Add, Remove, FindById, Find, GetAll | Generic class có constraint `where T: IEntity`. |
| **ProductService** | AddProduct, RemoveProduct, Search, Filter | Kiểm tra nghiệp vụ, gọi Repository, phát event. |
| **Program** | Main và menu | Điều khiển chương trình, nhập xuất dữ liệu, bắt exception. |

## 4. Yêu cầu chức năng

| Lựa chọn | Chức năng | Mô tả |
| :---: | :--- | :--- |
| **1** | Thêm sản phẩm | Nhập mã, tên, đơn giá, số lượng. Mã không được rỗng và không được trùng. |
| **2** | Xuất danh sách | In toàn bộ sản phẩm. Nếu danh sách rỗng cần thông báo phù hợp. |
| **3** | Tìm theo mã | Nhập mã sản phẩm, in thông tin nếu tìm thấy. |
| **4** | Tìm theo tên | Nhập từ khóa, in các sản phẩm có tên chứa từ khóa. |
| **5** | Lọc theo khoảng giá | Nhập giá nhỏ nhất và lớn nhất, dùng `Func<Product,bool>` để lọc. |
| **6** | Xóa sản phẩm | Nhập mã sản phẩm, nếu tồn tại thì xóa và phát event. |
| **7** | Tính tổng giá trị kho | Tổng = đơn giá * số lượng của tất cả sản phẩm. |
| **0** | Thoát | Kết thúc chương trình. |

## 5. Yêu cầu kỹ thuật
*   Không được để chương trình dừng đột ngột khi người dùng nhập sai dữ liệu.
*   Phải có ít nhất **2 exception tự tạo**.
*   Phải có generic class `Repository<T>`.
*   Phải có **event** khi thêm và xóa sản phẩm thành công.
*   Phải sử dụng `Func<Product, bool>` trong chức năng lọc hoặc tìm kiếm.
*   Không viết toàn bộ xử lý trong Main; nên tách `ProductService` và `Repository<T>`.
*   Tên biến, tên hàm, tên class phải rõ nghĩa.

## 6. Gợi ý menu

```text
===== PRODUCT MANAGER =====
1. Them san pham
2. Xuat danh sach
3. Tim theo ma
4. Tim theo ten
5. Loc theo khoang gia
6. Xoa san pham
7. Tinh tong gia tri kho
0. Thoat
Chon: 
```

## 7. Tiêu chí chấm điểm

| Tiêu chí | Điểm | Mô tả |
| :--- | :---: | :--- |
| **Class, property, constructor** | 2.0 | Đúng yêu cầu, có kiểm tra dữ liệu. |
| **Exception và xử lý lỗi** | 2.0 | Có exception tự tạo, try-catch hợp lý. |
| **Event hoặc Action event** | 2.0 | Thông báo khi thêm/xóa sản phẩm thành công. |
| **Generic Repository và Func** | 2.0 | `Repository<T>` hoạt động, có tìm kiếm/lọc bằng Func. |
| **Menu, kiểm thử, format code** | 2.0 | Chương trình dễ dùng, code rõ ràng, chạy ổn định. |

## 8. Yêu cầu nộp bài
*   Push code Github cá nhân.