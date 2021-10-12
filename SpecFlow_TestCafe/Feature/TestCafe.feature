Feature:Test Cafe


@mytag
Scenario: Verify success page upon submitting with name populated
	Given I Launch the Test Cafe webpage
	And I Input Name
	And I click on submit button
	Then I verify Success Page is displayed