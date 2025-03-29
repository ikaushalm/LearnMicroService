using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utitlity;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Url = SD.CouponAPIBase + "/api/coupon/",
                AccessToken = "",
                Data=couponDto
            });
        }

        public async Task<ResponseDto?> DeleteCouponsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponAPIBase + "/api/coupon/" + id,
                AccessToken = "",
            });
        }

        public async Task<ResponseDto?> GetAllCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon",
                AccessToken = "",
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/GetByCode" + couponCode,
                AccessToken = "",
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
           return await _baseService.SendAsync(new RequestDto
           {
               ApiType = SD.ApiType.GET,
               Url = SD.CouponAPIBase + "/api/coupon/" + id,
               AccessToken = "",
           });
        }

        public async Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Url = SD.CouponAPIBase + "/api/coupon/",
                AccessToken = "",
                Data = couponDto
            });
        }
    }
}
