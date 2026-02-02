namespace RelativityPracticeAssessment.Models;
public enum ReviewStatus {
  NotReviewed,
  Reviewed,
  Flagged
}


public class DocumentReview
{
  public string documentId { get; set; } = string.Empty;
  public string reviewerId { get; set; } = string.Empty;
  public ReviewStatus status { get; set; }
  public DateTime reviewedAt { get; set; }

  public DocumentReview(
    string docId,
    string revId,
    ReviewStatus reviewStatus,
    DateTime revAt
  )
  {
    documentId = docId;
    reviewerId = revId;
    status = reviewStatus;
    reviewedAt = revAt;
  }

}


