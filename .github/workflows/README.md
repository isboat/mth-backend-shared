# GitHub Package Publishing Workflow

This directory contains GitHub Actions workflows for automated CI/CD.

## Workflows

### build-and-publish.yml
Builds, tests, and publishes the MemeTokenHub.Shared NuGet package to GitHub Packages.

**Triggers:**
- Push to `main` or `develop` branches
- Pull requests to `main` or `develop` branches

**Jobs:**
1. **build**: Compiles and packs the NuGet package
2. **test**: Runs unit tests (if available)
3. **publish**: Publishes package to GitHub Packages

## Configuration

See `docs/GITHUB-SETUP.md` for setup instructions.
