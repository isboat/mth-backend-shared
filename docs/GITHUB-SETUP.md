# GitHub Secrets and Environment Setup

## Required GitHub Secrets

The CI/CD pipeline uses GitHub Secrets for sensitive information. Set up the following in your GitHub repository:

### Steps to Configure

1. Go to your GitHub repository
2. Navigate to **Settings** → **Secrets and variables** → **Actions**
3. Click **New repository secret**
4. Add the following secrets:

#### Secrets

No additional secrets are required beyond the default `GITHUB_TOKEN`, which is automatically provided by GitHub Actions.

The workflow uses `${{ secrets.GITHUB_TOKEN }}` for:
- Authenticating with GitHub Packages NuGet feed
- Creating releases
- Pushing packages

#### Environment Variables (Optional)

You can also set environment variables in the workflow file:

```yaml
env:
  REGISTRY: ghcr.io
  PACKAGE_NAME: MemeTokenHub.Shared
```

## GitHub Personal Access Token (for local development)

If consuming the package locally, create a PAT:

1. Go to GitHub Settings → Developer settings → Personal access tokens → Tokens (classic)
2. Click **Generate new token (classic)**
3. Configure the token:
   - **Token name**: `MemeTokenHub Development`
   - **Expiration**: 30 days (or your preference)
   - **Select scopes**: 
     - `repo` (full control of private repositories)
     - `read:packages` (read packages)
     - `write:packages` (write packages)
4. Click **Generate token**
5. Copy the token immediately (you won't be able to see it again)

## Using Local NuGet Configuration

For local development, configure NuGet with your PAT:

```bash
# Set up NuGet source
dotnet nuget add source "https://nuget.pkg.github.com/YOUR_ORG/index.json" \
  -n "github" \
  -u YOUR_USERNAME \
  -p YOUR_GITHUB_TOKEN \
  --store-password-in-clear-text
```

Or update `NuGet.config`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="github" value="https://nuget.pkg.github.com/YOUR_ORG/index.json" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <github>
      <add key="Username" value="YOUR_USERNAME" />
      <add key="ClearTextPassword" value="YOUR_GITHUB_TOKEN" />
    </github>
  </packageSourceCredentials>
</configuration>
```

## Workflow Permissions

The GitHub Actions workflow requires the following permissions:

```yaml
permissions:
  contents: read      # Read repository contents
  packages: write     # Write to GitHub Packages
```

These are automatically set in the workflow file, but ensure your GitHub Actions settings allow:
- Read and write repository contents
- Read and write packages

## Monitoring the Workflow

1. Go to your repository
2. Navigate to **Actions** tab
3. View the workflow run history
4. Click on a run to see detailed logs

### Troubleshooting Workflow Failures

- **Authentication Failed**: Verify `GITHUB_TOKEN` has proper permissions
- **Package Not Found**: Check repository name case sensitivity
- **Tests Failed**: Review test output in the Actions log
- **Publish Failed**: Ensure the branch is main or develop

## Branch Protection Rules (Recommended)

For production-grade deployments, set branch protection rules:

1. Go to **Settings** → **Branches**
2. Add rule for `main` branch
3. Require status checks to pass before merging
4. Select the workflow jobs you want to check (e.g., `build`, `test`)
5. Require branches to be up to date before merging

## Release Strategy

The workflow implements:

- **Versioning**: `1.0.{build-number}`
- **Pre-releases**: `1.0.{build-number}-preview` for non-main branches
- **Automatic Releases**: Created on main branch pushes
- **Artifacts**: NuGet packages stored in GitHub Actions artifacts for 30 days

## Updating the Workflow

To modify the CI/CD workflow:

1. Edit `.github/workflows/build-and-publish.yml`
2. Commit and push to a branch
3. Create a pull request to test the changes
4. Merge to apply the changes
5. Subsequent builds will use the updated workflow
