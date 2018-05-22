#include<stdio.h>
int main(int argc, char *argv[])
{
    int x,y,n;
    int sss[200][200];
    scanf("%d",&x);
    scanf("%d",&y);
    scanf("%d",&n);
    //input array
    for(int i=0;i<x;i++)
        for(int j=0;j<y;j++)
        {
            int t;
            scanf("%d",&t);
            sss[i][j]=t;
        }
    if(n==0)
    {
        for(int i=x-1;i>=0;i--)
        for(int j=0;j<y;j++)
        {
            printf("%d",sss[i][j]);
        }
    }
    if(n==1)
    {
        for(int i=0;i<x;i++)
        for(int j=y-1;j>=0;j--)
        {
            printf("%d",sss[i][j]);
        }
    }
    return 0;
}