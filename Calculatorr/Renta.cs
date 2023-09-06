using System;

namespace Calculatorr
{
    public class Renta
    {
        private Action renta_day10movie_true;
        private int day;
        private Movie movie;

        public Renta(Movie movie, int day)
        {
            this.movie = movie;
            this.day = day;
        }

        public int RentaPrice()
        {
           return day * movie.price;
        }
    }
}