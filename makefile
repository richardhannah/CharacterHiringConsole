.PHONY test:
test:
	dotnet test --results-directory:TestResults --collect:"XPlat Code Coverage"