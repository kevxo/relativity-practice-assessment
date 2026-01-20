using RelativityPracticeAssessment.Models;

namespace RelativityPracticeAssessment.Services;

public class ReviewAnalyticsService
{
  public Dictionary<string, int> GetReviewCountPerReviewer(IEnumerable<DocumentReview> reviews)
  {
    Dictionary<string, int> record = new Dictionary<string, int>();
    foreach(var review in reviews)
    {
      if (review.status == ReviewStatus.Reviewed || review.status == ReviewStatus.Flagged)
      {
        if (record.ContainsKey(review.reviewerId))
        {
          record[review.reviewerId] += 1;
        } else
        {
          record[review.reviewerId] = 1;
        }
      }
    }

    return record;
  }

  Dictionary<string, ReviewStatus> GetFinalStatusPerDocument(IEnumerable<DocumentReview> reviews)
  {
    Dictionary<string, ReviewStatus> record = new Dictionary<string, ReviewStatus>();

    foreach(var review in reviews)
    {
      var docReviews = reviews.Where(item => item.documentId == review.documentId);

      if (docReviews.Any(rev => rev.status == ReviewStatus.Flagged))
      {
        record[review.documentId] = ReviewStatus.Flagged;
      } else if (docReviews.All(rev => rev.status == ReviewStatus.Reviewed))
      {
        record[review.documentId] = ReviewStatus.Reviewed;
      } else
      {
        record[review.documentId] = ReviewStatus.NotReviewed;
      }
    }

    return record;
  }

  List<string> GetTopReviewers(IEnumerable<DocumentReview> reviews, IEnumerable<Reviewer> reviewers, int topN)
  {
    var sortTopReviewers = GetReviewCountPerReviewer(reviews).OrderByDescending(kvp => kvp.Value);
    var getTopNReviewers = sortTopReviewers.Select(kvp => kvp.Key).ToList().Take(topN);

    return getTopNReviewers.ToList();
  }
}