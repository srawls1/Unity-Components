using System.Collections;

public interface ConversationVisitor
{
	IEnumerator VisitLine(LineNode node);
	IEnumerator VisitChoice(ChoiceNode node);
}
