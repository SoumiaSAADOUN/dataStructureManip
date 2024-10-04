class MostPopularMovie
{
    public Dictionnary<Guid, int> moviesCount;
    public HashSet<Guid> visitedUsers;

    public MostPopularMovie()
    {
        moviesCount = new Dictionary<Guid, int>();
        visitedUsers = new HashSet<Guid>();
    }
    void CountMovies(User user)
    {
        if (visitedUsers.Contains(user.UserID))
        {
            return;
        }

        visitedUsers.Add(user.userID);

        foreach (var movie in user.wishList)
        {
            if (moviesCount.ContainsKey(movie.movieId))
                moviesCount[movie.movieId]++;
            else moviesCount.Add(movie.movieId, 1);
        }

        foreach (var friend in user.friends)
        {
            CountMovies(friend);
        }

    }
    Guid FindMostPopularMovie(User user)
    {
        CountMovies(user);
        int maxCount = 0;
        Guid movieId = Guid.Empty;

        foreach (var movie in moviesCount)
        {
            if (movie.Value > maxCount)
            {
                maxCount = movie.Value;
                movieId = movie.Key;
            }
        }

        return movieId;
    }

}

class User
{
    public Guid userID;
    public List<Movie> wishList;
    public List<User> friends;
    public User()
    {
        this.userID = Guid.NewGuid();
        this.wishList = new List<Movie>();
        this.friends = new List<User>();
    }
}

class Movie
{
    public Guid movieId;
    public string title;
    public string director;

}