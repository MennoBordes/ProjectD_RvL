using System.Collections.Concurrent;

using BlockChainData = Server.Classes.NewBlock.Block;

namespace Server.Classes.Queue
{

  public static class PushQueue
  {
    private static ConcurrentQueue<BlockChainData> _queue;
    public static ConcurrentQueue<BlockChainData> Queue
    {
      get
      {
        if (_queue == null)
        {
          _queue = new ConcurrentQueue<BlockChainData>();
        }
        // if queue is more than certain amount
        // push all in queue to the nodes
        // if (_queue.Count >= 10)
        // {
        //   // Save the items to the nodes
        //   SaveToNodes(_queue);

        //   _queue = new ConcurrentQueue<BlockChainData>();
        // }
        return _queue;
      }
    }
    // https://stackoverflow.com/questions/19452881/how-to-maintain-state-or-queue-of-requests-in-web-api
    public static void SaveToNodes(ConcurrentQueue<BlockChainData> queue)
    {
      foreach (var item in queue)
      {
        // SaveItemToNode(queue);
      }
    }

  }

}