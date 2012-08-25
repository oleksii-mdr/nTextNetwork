using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using NUnit.Framework;

namespace nTextNetwork.Lucene.Test
{
    [TestFixture]
    public class HelloWorldLuceneTest
    {
        [Test]
        public void HelloWorldTest()
        {
            Directory directory = new RAMDirectory();
            Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_29);
            IndexWriter writer = new IndexWriter(directory, 
                analyzer, 
                IndexWriter.MaxFieldLength.UNLIMITED);

            Document doc = new Document();
            doc.Add(new Field("id", "1", Field.Store.YES, Field.Index.NO));
            doc.Add(new Field("postBody", "sample test", Field.Store.YES, Field.Index.ANALYZED));
            writer.AddDocument(doc);
            writer.Optimize();
            writer.Commit();
            writer.Close();

            QueryParser parser = new QueryParser(Version.LUCENE_29, "postBody", analyzer);
            Query query = parser.Parse("sample test");

            //Setup searcher
            IndexSearcher searcher = new IndexSearcher(directory, true);
            //Do the search
            var hits = searcher.Search(query, null, 10);

            for (int i = 0; i < hits.TotalHits; i++)
            {
                var doc1 = hits.ScoreDocs[i];
            }

            searcher.Close();
            directory.Close();
        }
        
    }
}