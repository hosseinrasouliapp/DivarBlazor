using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarClone.Domain.Entities
{
  
    public class Advertisement
    {
        public Guid Id { get; private set; } // شناسه منحصر به فرد آگهی
        public string Title { get; private set; } = string.Empty; // عنوان آگهی
        public string Description { get; private set; } = string.Empty; // توضیحات آگهی
        public decimal? Price { get; private set; } // قیمت (می‌تواند null باشد برای آگهی‌های "توافقی")
        public DateTime PublicationDate { get; private set; } // تاریخ انتشار
        public DateTime LastModifiedDate { get; private set; } // تاریخ آخرین ویرایش
        public bool IsPublished { get; private set; } // آیا آگهی منتشر شده است؟
        public bool IsSold { get; private set; } // آیا کالا فروخته شده است؟

        // شناسه کاربری که آگهی را ثبت کرده است (بعداً به Entity کاربر مرتبط می‌شود)
        public Guid UserId { get; private set; } // یا int اگر شناسه کاربر شما int است

        // TODO: سایر خصوصیات مانند CategoryId, LocationId, Images, etc. را بعداً اضافه خواهیم کرد.

        // سازنده خصوصی برای استفاده توسط EF Core یا Factory
        private Advertisement() { }

        // سازنده عمومی برای ایجاد آگهی جدید
        public Advertisement(Guid userId, string title, string description, decimal? price)
        {
            Id = Guid.NewGuid();
            UserId = userId; Title = title; // اینجا می‌توانیم ولیدیشن‌های اولیه را هم اضافه کنیم
            Description = description;
            Price = price;
            PublicationDate = DateTime.UtcNow;
            LastModifiedDate = DateTime.UtcNow;
            IsPublished = false; // به طور پیش‌فرض منتشر نشده در نظر می‌گیریم
            IsSold = false;
        }

        // متدهایی برای تغییر وضعیت آگهی (مثال)
        public void UpdateDetails(string title, string description, decimal? price)
        {
            // TODO: اضافه کردن ولیدیشن
            Title = title;
            Description = description;
            Price = price;
            LastModifiedDate = DateTime.UtcNow;
        }

        public void Publish()
        {
            if (!IsPublished)
            {
                IsPublished = true;
                PublicationDate = DateTime.UtcNow; // یا شاید PublicationDate اولیه باید حفظ شود
                LastModifiedDate = DateTime.UtcNow;
            }
        }

        public void Unpublish()
        {
            if (IsPublished)
            {
                IsPublished = false;
                LastModifiedDate = DateTime.UtcNow;
            }
        }

        public void MarkAsSold()
        {
            IsSold = true;
            LastModifiedDate = DateTime.UtcNow;
        }
    }

}
