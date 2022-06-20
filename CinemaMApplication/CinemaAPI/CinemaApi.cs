using CinemaMApplication.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMApplication.CinemaAPI
{
    class CinemaApi
    {
        HttpClient client;

        public CinemaApi()
        {
            HttpClientHandler insecureHandler = GetInsecureHandler();
            client = new HttpClient(insecureHandler);
        }
        public async void RegisterUser(UserRequest user)
        {
            try
            {

                var api = "https://10.0.2.2:5001/api/user";
                var json = JsonConvert.SerializeObject(user, Formatting.Indented);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(api, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Success");
                }
                else
                {
                    Debug.WriteLine("Status code " + response.StatusCode);
                }
            } catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

       
        public async Task<UserResponse> checkLogin(string email, string password)
        {
            //?email=antonian@abv.bg&password=123456
            var response = await client.GetAsync("https://10.0.2.2:5001/api/login" + "?email=" + email + "&password=" + password);
            var content = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserResponse>(content);
            return user;
        }

        public async Task<List<GenreResponse>> getAllGenres()
        {
            var response = await client.GetAsync("https://10.0.2.2:5001/api/genre");
            var content = await response.Content.ReadAsStringAsync();
            var genres = JsonConvert.DeserializeObject<List<GenreResponse>>(content);
            return genres;
        }

        public async Task<List<CinemaRoomResponse>> getAllCinemaRooms()
        {
            var response = await client.GetAsync("https://10.0.2.2:5001/api/cinemaroom");
            var content = await response.Content.ReadAsStringAsync();
            var cinemaRooms = JsonConvert.DeserializeObject<List<CinemaRoomResponse>>(content);
            return cinemaRooms;
        }

        public async void addNewFilm(FilmRequest filmEntity)
        {
            var api = "https://10.0.2.2:5001/api/film";
            var json = JsonConvert.SerializeObject(filmEntity, Formatting.Indented);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(api, content);

        }

        public async Task<List<FilmResponse>> getAllFilms()
        {
            List<FilmResponse> allFilms = null;
            try
            {
                var response = await client.GetAsync("https://10.0.2.2:5001/api/film");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    allFilms = JsonConvert.DeserializeObject<List<FilmResponse>>(content);
                }
            }catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return allFilms;

        }

        public async void makeReservation(ReservationRequest reservation)
        {
            var api = "https://10.0.2.2:5001/api/reservation";
            var json = JsonConvert.SerializeObject(reservation, Formatting.Indented);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(api, content);
        }

        public async void deleteFilm(int filmID)
        {
            var api = "https://10.0.2.2:5001/api/film/" + filmID;
            await client.DeleteAsync(api);
        }

        public async Task<FilmResponse> getFilmById(int filmID)
        {
            FilmResponse Film = null;
            try
            {
                var response = await client.GetAsync("https://10.0.2.2:5001/api/film/" + filmID);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Film = JsonConvert.DeserializeObject<FilmResponse>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return Film;
        }
        public async  void editFilm(int filmID, FilmRequest filmRequest)
        {
            var api = "https://10.0.2.2:5001/api/film/" + filmID;
            
            var json = JsonConvert.SerializeObject(filmRequest, Formatting.Indented);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
             await client.PutAsync(api, content);
         

        }

        public async Task<UserResponse> getReservationByUserId(int userId)
        {
            UserResponse user = null;
            try
            {
                var response = await client.GetAsync("https://10.0.2.2:5001/api/user/" + userId);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<UserResponse>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return user;

        }

         public async void deleteReservation(int reservationId)
        {
            var api = "https://10.0.2.2:5001/api/reservation/" + reservationId;
            await client.DeleteAsync(api);
        }
         public HttpClientHandler GetInsecureHandler()
         {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
                 return handler;
         }
    }
}
