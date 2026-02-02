using System.Text.Json;// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Xml;
using RelativityPracticeAssessment.Models;
using RelativityPracticeAssessment.Services;

Console.WriteLine("Hello, World!");

Reviewer rev1 = new Reviewer("1", "Kevin");
Reviewer rev2 = new Reviewer("2", "Sean");
Reviewer rev3 = new Reviewer("3", "Alex");

IEnumerable<Reviewer> reviewers = [rev1, rev2, rev3];


DocumentReview docRev1 = new DocumentReview("1", rev1.Id, ReviewStatus.Reviewed, DateTime.UtcNow);
DocumentReview docRev2 = new DocumentReview("2", rev1.Id, ReviewStatus.Flagged, DateTime.UtcNow);
DocumentReview docRev3 = new DocumentReview("3", rev1.Id, ReviewStatus.Flagged, DateTime.UtcNow);
DocumentReview docRev4 = new DocumentReview("4", rev2.Id, ReviewStatus.NotReviewed, DateTime.UtcNow);
DocumentReview docRev5 = new DocumentReview("5", rev3.Id, ReviewStatus.NotReviewed, DateTime.UtcNow);
DocumentReview docRev6 = new DocumentReview("6", rev2.Id, ReviewStatus.Reviewed, DateTime.UtcNow);

IEnumerable<DocumentReview> reviews = [docRev1, docRev2, docRev3, docRev4, docRev5, docRev6];

var analyticsService = new ReviewAnalyticsService();

string pretty = JsonConvert.SerializeObject(analyticsService.GetReviewCountPerReviewer(reviews), Newtonsoft.Json.Formatting.Indented);
Console.WriteLine(pretty);

string prettyTwo = JsonConvert.SerializeObject(analyticsService.GetFinalStatusPerDocument(reviews), Newtonsoft.Json.Formatting.Indented);
Console.WriteLine(prettyTwo);

string prettyThree = JsonConvert.SerializeObject(analyticsService.GetTopReviewers(reviews, reviewers, 2), Newtonsoft.Json.Formatting.Indented);
Console.WriteLine(prettyThree);
