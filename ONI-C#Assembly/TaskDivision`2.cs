// Decompiled with JetBrains decompiler
// Type: TaskDivision`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
internal class TaskDivision<Task, SharedData> where Task : DivisibleTask<SharedData>, new()
{
  public Task[] tasks;

  public TaskDivision(int taskCount)
  {
    this.tasks = new Task[taskCount];
    for (int index = 0; index != this.tasks.Length; ++index)
      this.tasks[index] = new Task();
  }

  public TaskDivision()
    : this(CPUBudget.coreCount)
  {
  }

  public void Initialize(int count)
  {
    int num = count / this.tasks.Length;
    for (int index = 0; index != this.tasks.Length; ++index)
    {
      this.tasks[index].start = index * num;
      this.tasks[index].end = this.tasks[index].start + num;
    }
    DebugUtil.Assert(this.tasks[this.tasks.Length - 1].end + count % this.tasks.Length == count);
    this.tasks[this.tasks.Length - 1].end = count;
  }

  public void Run(SharedData sharedData, int threadIndex)
  {
    foreach (Task task in this.tasks)
      task.Run(sharedData, threadIndex);
  }
}
