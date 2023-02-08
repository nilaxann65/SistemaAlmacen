namespace Helpers
{

    public class ResponseBody
    {
        public int status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public abstract class Responses
    {
        public static ResponseBody Success(string message = "Exito", object data = null)
        {
            return new ResponseBody
            {
                status = 200,
                Message = message,
                Data = data
            };
        }
        public static ResponseBody NotFound(string message = "No se ha encontrado el recurso solicitado")
        {
            return new ResponseBody
            {
                status = 404,
                Message = message,
                Data = null
            };
        }
        public static ResponseBody BadRequest(string message = "Error en la solicitud", string error = "Error no reconocido")
        {
            return new ResponseBody
            {
                status = 400,
                Message = message,
                Data = null
            };
        }
        public static ResponseBody InternalServerError(string message = "Error en el servidor", string error = "Error no reconocido")
        {
            return new ResponseBody
            { 
                status = 500,
                Message = message,
                Data = error
            };
        }
    }
}