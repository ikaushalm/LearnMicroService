using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public CouponApiController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> coupons = _db.Coupons.ToList();
                _mapper.Map<IEnumerable<CouponDto>>(coupons);

                _response.Result = coupons;

            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }


        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(x => x.CouponId == id);
                _mapper.Map<CouponDto>(coupon);
                _response.Result = coupon;

            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                _response.IsSuccess = false;

            }

            return _response;
        }


        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto Get(string code)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(x => x.CouponCode.ToLower() == code.ToLower());
                _mapper.Map<CouponDto>(coupon);
                _response.Result = coupon;

            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                _response.IsSuccess = false;

            }

            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto coupon)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(coupon);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                _response.IsSuccess = false;

            }

            return _response;
        }


        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto coupon)
        {
            try
            {

                Coupon obj = _mapper.Map<Coupon>(coupon);
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                _response.IsSuccess = false;

            }

            return _response;
        }
        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {

                Coupon obj = _db.Coupons.First(x => x.CouponId == id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                _response.IsSuccess = false;

            }

            return _response;
        }

    }
}
